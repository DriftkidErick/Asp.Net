using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TroubleTickets.Models
{
    public class TroubleTicketDataAccessLayer
    {
        string connectionString; //String that will receive the connectin string form the constructor

        private readonly IConfiguration _configuration; //Instance of IConfiguration class... allows us to read in from gonfig file like appsettings

        //the razor page that creates this data factory and passes the configuration object to it

        public TroubleTicketDataAccessLayer(IConfiguration configuration)
        {
            //Via the configuration object we could colle the connection string for the project
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(TroubleTicketModel ticket)
        {
            //A little more efficent, because it deleteds the sql connection and anything inside when brackets closed.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SQL statemen to add a record with stater information (lacks response/solution that is for this update)
                //We are using parameter to avoid issuesd with hacks like SQL Injection Attacks

                string sql = "INSERT into TroubleTickets (Ticket_Title, Ticket_Desc, Category, Reporting_Email, Orig_Date) VALUES (@Ticket_Title, @Ticket_Desc, @Category, @Reporting_Email, @Orig_Date);";

                //Iniitialze feedback to avoid re-using error messages once they have been fixed
                ticket.Feedback = "";

                //Use try Seeing we are connecting with a resource we cannot control, if we get an error, it jumps to the catch

                try
                {
                    //Creating a command object that uses SQL command and connection string
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //Tell Command our SQL String
                        command.CommandType = CommandType.Text;

                        //Fill in parameters
                        command.Parameters.AddWithValue("@Ticket_Title", ticket.Ticket_Title);
                        command.Parameters.AddWithValue("@Ticket_Desc", ticket.Ticket_Desc);
                        command.Parameters.AddWithValue("@Category", ticket.Category);
                        command.Parameters.AddWithValue("@Reporting_Email", ticket.Reporting_Email);
                        command.Parameters.AddWithValue("@Orig_Date", DateTime.Now);

                        //Connect to the Database (THe connection can be the first issue we can run across)
                        connection.Open();

                        //preform the command. This Command returns the number of records effected/added
                        //So, we use that number and concatenate to a string to provide feedback
                        ticket.Feedback = command.ExecuteNonQuery().ToString() + " Record Added";

                        //We are done our work, close the connection (hang up)

                        connection.Close();
                    }
                }

                catch (Exception err)
                {
                    //If an error occurs, let's list is as the feedback
                    ticket.Feedback = "ERROR: " + err.Message;
                }

                //Return RedirectToAction("Index); //Send us over to the index action at this point
            }
        }

        //To View Active Trouble Ticket Details
        public IEnumerable<TroubleTicketModel> GetActiveRecords()
        {
            List<TroubleTicketModel> lstTix = new List<TroubleTicketModel>(); //List to hold tickets from Db Table

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT * FROM TroubleTickets ORDER BY Orig_Date;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(); //Populate the data reader (rdr) from DB

                    //Loop through each record
                    //For each record fill a temp trouble ticket object with current record's data
                    //Then add this temp ticket object to the list. List will be available to the CSHTML to format

                    while (rdr.Read())
                    {
                        TroubleTicketModel ticket = new TroubleTicketModel();

                        ticket.Ticket_ID = Convert.ToInt32(rdr["Ticket_ID"]); //Needed to convert sting to ticket

                        ticket.Ticket_Title = rdr["Ticket_Title"].ToString();
                        ticket.Category = rdr["Category"].ToString();
                        ticket.Reporting_Email = rdr["Reporting_Email"].ToString();
                        ticket.Orig_Date = DateTime.Parse(rdr["Orig_Date"].ToString());
                        ticket.Active = Boolean.Parse(rdr["Active"].ToString());
                        ticket.Responder_Email = rdr["Responder_Email"].ToString();
                        ticket.Responder_Notes = rdr["Responder_Notes"].ToString();

                        lstTix.Add(ticket); //Add newly created ticket and add to the list of tickets
                    }

                    con.Close();
                }
            }

            catch (Exception err)
            {
                //Nothing at the moment
            }
            return lstTix; //Return the list so the Razor page can build HTML table based on this list
        }

    }
}

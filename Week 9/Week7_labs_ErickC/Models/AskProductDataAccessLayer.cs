using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Added for us of SQL DAtabase components
using System.Data;
using System.Data.SqlClient;
//Using Models from this project
using Week6_labs_ErickC.Models;
//Added in order to use ICONFIG, so we can get our DB connection string from the appsettings.JSon file
using Microsoft.Extensions.Configuration;

namespace Week6_labs_ErickC.Models
{
    public class AskProductDataAccessLayer
    {
        string connectionString; //String that will recieve the connection string from a constructor

        private readonly IConfiguration _configuration; //Instance of IConfig class allows us to read in from gonFig file like appsettings.json

        //Razor Pages that creates this data factory and passes the configuration object to it
        public AskProductDataAccessLayer(IConfiguration configuration)
        {
            //Via the configuration object, we could collect the connection string for this project
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(AskProductModel tAsk)
        {
            //A little more efficient, because it deletes the SQL Connection and anything insiude when brackets are closed

            using(SqlConnection connection = new SqlConnection(connectionString)) 
            {
                //SQL statement to Add a record with starter information (lacks response/ solution  that is for Update)
                //We are using parameters to avoid issues with hacks like SQL Injection attacks

                string sql = "INSERT Into AskProduct (Ask_Brand, Ask_Model, Ask_Category, Ask_Quantity, Ask_Description, Cust_Email, Open_Date) VALUES (@Ask_Brand, @Ask_Model, @Ask_Category, @Ask_Quantity, @Ask_Description, @Cust_Email, @Open_Date);";

                //Initialize the feedback to avoid re-using error messages once they have been fixed
                tAsk.Feedback = "";

                //Use try seeing we are connecting with a resource we cannot control, if we get an error, it jumps to catch
                try
                {
                    //Creating a command object that uses SQL command and connection string

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //Tell command our SQL
                        command.CommandType= CommandType.Text;

                        //Fill in the parameter
                        command.Parameters.AddWithValue("@Ask_Brand", tAsk.Ask_Brand);
                        command.Parameters.AddWithValue("@Ask_Model", tAsk.Ask_Model);
                        command.Parameters.AddWithValue("@Ask_Category", tAsk.Ask_Category);
                        command.Parameters.AddWithValue("@Ask_Quantity", tAsk.Ask_Quantity);
                        command.Parameters.AddWithValue("@Ask_Description", tAsk.Ask_Description);
                        command.Parameters.AddWithValue("@Cust_Email", tAsk.Cust_email);
                        command.Parameters.AddWithValue("@Open_Date", DateTime.Now);

                        //Connect to the Database (The connection can be the first issue we can run across)
                        connection.Open();

                        //Prefrom the command. This command returns the number of records effected/added
                        //So, we use that number and concatenatre to a string to provide feedback
                        tAsk.Feedback = command.ExecuteNonQuery().ToString() + " Record Added";

                        //Close the connection string
                        connection.Close();
                    }

                }


                catch (Exception err)
                {
                    //If an error occurs, Lets list it as the feedback
                    tAsk.Feedback += "ERROR: " + err.Message;
                }


            }
        }

        public IEnumerable<AskProductModel> GetActiveRecords()
        {
            List<AskProductModel> lstTix = new List<AskProductModel>(); //List to hold tickets from Db Table

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT * FROM AskProduct ORDER BY Open_Date;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(); //Populate the data reader (rdr) from DB

                    //Loop through each record
                    //For each record fill a temp trouble ticket object with current record's data
                    //Then add this temp ticket object to the list. List will be available to the CSHTML to format

                    while (rdr.Read())
                    {
                        AskProductModel tAsk = new AskProductModel();

                        tAsk.Ask_ID = Convert.ToInt32(rdr["Ask_ID"]); //Needed to convert sting to ticket

                        tAsk.Ask_Brand = rdr["Ask_Brand"].ToString();
                        tAsk.Ask_Model = rdr["Ask_Model"].ToString();
                        tAsk.Ask_Category = rdr["Ask_Category"].ToString();
                        tAsk.Open_Date = DateTime.Parse(rdr["Open_Date"].ToString());
                        tAsk.Ask_Active = Boolean.Parse(rdr["Ask_Active"].ToString());
                        tAsk.Cust_email = rdr["Cust_Email"].ToString() ;
                        tAsk.Support_email = rdr["Support_Email"].ToString();
                        tAsk.Support_Notes = rdr["Support_Notes"].ToString();

                        
                        lstTix.Add(tAsk); //Add newly created ticket and add to the list of tickets
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

        public AskProductModel GetOneRecord(int? id)
        {
            AskProductModel ask = new AskProductModel();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT * FROM AskProduct WHERE Ask_ID = @Ask_ID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Ask_ID", id);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ask.Ask_ID = Convert.ToInt32(rdr["Ask_ID"]);
                        ask.Ask_Brand = rdr["Ask_Brand"].ToString();
                        ask.Ask_Model = rdr["Ask_Model"].ToString();

                        ask.Ask_Category = rdr["Ask_Category"].ToString();

                        ask.Cust_email = rdr["Cust_email"].ToString();
                        ask.Open_Date = DateTime.Parse(rdr["Open_Date"].ToString());
                        ask.Ask_Active = Boolean.Parse(rdr["Ask_Active"].ToString());
                        ask.Support_email = rdr["Support_email"].ToString();
                        ask.Support_Notes = rdr["Support_Notes"].ToString();



                        DateTime tempDate;
                        if (rdr["Close_Date"] != null && DateTime.TryParse(rdr["Close_Date"].ToString(), out tempDate))
                        {
                            ask.Close_Date = tempDate;
                        }

                        //ask.Ask_Description = rdr["Ask_Description"].ToString();

                    }

                    con.Close();

                }
            }

            catch (Exception err)
            {
                ask.Feedback = "ERROR: " + err.Message;
            }

            return ask;
        }

        public void UpdateTicket(AskProductModel tAsk) //You are on Slide 21/27 adding the update
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    string strSQL;

                    if (tAsk.Ask_Active == false)
                    {
                        strSQL = "UPDATE AskProduct SET Support_email = @Support_email, Support_Notes = @Support_Notes, Ask_Brand = @Ask_Brand, Ask_Model = @Ask_Model, Ask_Category = @Ask_Category, Cust_Email = @Cust_Email, Ask_Active = @Ask_Active, Close_Date = @Close_Date WHERE Ask_ID = @Ask_ID;";
                    }

                    else
                    {
                        strSQL = "UPDATE AskProduct SET Support_email = @Support_email, Support_Notes = @Support_Notes, Ask_Brand = @Ask_Brand, Ask_Model = @Ask_Model, Ask_Category = @Ask_Category, Cust_Email = @Cust_Email, Ask_Active = @Ask_Active  WHERE Ask_ID = @Ask_ID;"; 
                        
                    }

                    //config the command obj
                    cmd.CommandText = strSQL;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

 
                    //fill form with values
                    cmd.Parameters.AddWithValue("@Support_email", tAsk.Support_email);
                    cmd.Parameters.AddWithValue("@Support_Notes", tAsk.Support_Notes);

                    cmd.Parameters.AddWithValue("@Ask_Brand", tAsk.Ask_Brand);
                    cmd.Parameters.AddWithValue("@Ask_Model", tAsk.Ask_Model);
                    cmd.Parameters.AddWithValue("@Ask_Category", tAsk.Ask_Category);
                    cmd.Parameters.AddWithValue("@Cust_email", tAsk.Cust_email);


                    //if ticket is being closed set the close date to now
                    if (tAsk.Ask_Active == false)
                    {
                        cmd.Parameters.AddWithValue("@Close_Date", DateTime.Now);
                    }
                   

                    cmd.Parameters.AddWithValue("@Ask_Active", tAsk.Ask_Active);
                    cmd.Parameters.AddWithValue("@Ask_ID", tAsk.Ask_ID);

                    //Do the update
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            catch (Exception err)
            {
                //if there is a runtime error
                tAsk.Feedback = "ERROR: " + err.Message;
            }
        }

        public AskProductModel DeleteTicket(int? id)
        {
            AskProductModel ticket = new AskProductModel();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "DELETE FROM AskProduct WHERE Ask_ID = @Ask_ID";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Ask_ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }

            catch (Exception err)
            {
                ticket.Feedback = "ERROR: " + err.Message;
            }

            return ticket;
        }
    }
}

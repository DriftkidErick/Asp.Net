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
    }
}

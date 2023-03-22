using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SE256_Activity_ErickC.App_Code
{
    public class EProducts : Product
    {
        private DateTime releaseDate;
        private int productID;
        private int quantity;
        private double weight;

        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }

            set
            {
                releaseDate = value;
            }

        }

        public int ProductID
        { 
            get
            {
                return productID; 
            }

            set 
            {
                if (value >= 0)
                {
                    productID = value;
                }

                else
                {
                    feedback += "Error: Sorry you entered an invalid Product ID";
                }
            }   
        }

        public int Quantity
        {
            get 
            {
                return quantity;
            }

            set 
            {
                if (value >= 0)
                {
                    quantity = value;
                }

                else
                {
                    feedback += "Error: Sorry you entered an invalid quantity";
                }
            }
        }

        public double Weight
        {
            get 
            {
                return weight;
            }

            set
            {
                if (value > 0)
                {
                    weight = value;
                }

                else
                {
                    feedback += "Error: Sorry you entered the an invalid weight";
                }
            }
        }

        // SQL Server Login

        private string GetConnected()
        {
            return @"Server=sql.neit.edu\studentsqlserver,4500;Database=SE256_ECordon;User Id=SE256_ECordon;Password=008004507;";
        }

        //Here we make a deafualt constructor

        public EProducts() : base()
        { 
            quantity = 0;
            weight = 0.0;
            releaseDate = DateTime.Now;
        }


        //Here is the information to push the stuff to SQL

       
        
        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initiate it's properties
            Conn.ConnectionString = GetConnected(); //Who, what, where of Database

            

            string strSQL = "INSERT INTO EProduct (Brand, Model, Category, Description, Price, ReleaseDate, Quantity, Weight) VALUES (@Brand, @Model, @Category, @Description, @Price, @ReleaseDate, @Quantity, @Weight)";

            //Bark out command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL; //Commander knows what to say
            comm.Connection = Conn;    //Heres the phone

           
            //Fill in parameters
            
            comm.Parameters.AddWithValue("@Brand", Brand);
            comm.Parameters.AddWithValue("@Model", Model);
            comm.Parameters.AddWithValue("@Category", Category);
            comm.Parameters.AddWithValue("@Description", Description);
            comm.Parameters.AddWithValue("@Price", Price);
            comm.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            comm.Parameters.AddWithValue("@Quantity", Quantity);
            comm.Parameters.AddWithValue("@Weight", Weight);
            

            //try to connect to the server
            try
            {
                Conn.Open(); //Open connection ot DB

                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records."; //Report that we made the connection and added a record
                Conn.Close(); //closes connection
            }
            catch (Exception err)  // if we get here there is an issue
            {
                strResult = "Error: " + err.Message; //Sets feedback to state there is an error
            }

            finally
            {

            }

            //Return resulting feedback string
            return strResult;
        }

    }
}
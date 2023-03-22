using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SE256_Activity_ErickC.App_Code
{
    public class EProducts : Product
    {
        private DateTime releaseDate;
        private int productID;
        private int quantity;
        private double weight;
        private bool active;

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

        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
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
            active = true;
            
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

            

            string strSQL = "INSERT INTO EProduct2 (Brand, Model, Category, Description, Price, ReleaseDate, Quantity, Weight, Active) VALUES (@Brand, @Model, @Category, @Description, @Price, @ReleaseDate, @Quantity, @Weight, @Active)";

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
            comm.Parameters.AddWithValue("@Active", Active);
            

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

        public DataSet SearchEProducts_DS(String strBrand, String strModel)
        {
            //Create a dataset to return filled in
            DataSet ds = new DataSet();

            //Create a command for our SQl Statement
            SqlCommand comm = new SqlCommand();

            //Write a Select Statement to preform Search
            String strSQL = "Select ProductID, Brand, Model, Price, Quantity FROM EProduct2 WHERE 0=0";

            //If the Product/ Brand is filled in include it as a search criteria 
            if(strBrand.Length > 0)
            {
                strSQL += " AND Brand LIKE @Brand";
                comm.Parameters.AddWithValue("@Brand", "%" + strBrand + "%");
            }

            if(strModel.Length > 0)
            {
                strSQL += " AND Model LIKE @Model";
                comm.Parameters.AddWithValue("@Model", "%" + strModel + "%");
            }

            //Create Db tools and Configure
            SqlConnection conn = new SqlConnection();

            //Creat who what where when
            string strConn = GetConnected();
            conn.ConnectionString = strConn;

            //Fill in basic info to command object
            comm.Connection = conn;  //Tells the commander what to use
            comm.CommandText = strSQL; //Tells the command what to say

            //Creat Data Adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm; //Commander needs a translator(dataAdaptor) to speak with datasets

            //Get data
            conn.Open();  //Open the Connection (pick up the phone
            da.Fill(ds, "EProducts_Temp"); //Fill in dataset with results from database and call it

            conn.Close(); //Close the connection (Hangs up the phone)

            //return the data
            return ds;
        }

        //New DataReader Vers - Part one of Drill-down Search (takes serach params to narrow search results)
        
        public SqlDataReader FindOneEProduct(int intEProductID)
        {
            //Create and Initialize the DB tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            string strConn = GetConnected();

            //My SQL command string to pull up one EProduct's data
            string sqlString = "SELECT * FROM EProduct2 WHERE ProductID = @ProductID;";

            conn.ConnectionString = strConn; //Tell the connection objec the who/what/where

            //Give the command object the info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@ProductID", intEProductID);

            //Open the Database Connection and Yell our SQL Command
            conn.Open();

            //Return some form of feedback
            return comm.ExecuteReader(); //Return the dataset to be used by other( the calling form)


        }

        public string DeleteOneProduct(int intEProductID)
        {
            Int32 intRecords = 0;
            string strResult = "";

            //Create and Initialize the DB tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My Sql command string to pull up one Ebook's data
            string sqlString = "DELETE FROM EProduct2 WHERE ProductID = @ProductID;";

            //Tell the connection object the who/what/where
            conn.ConnectionString= strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@ProductID", intEProductID);

            try
            {
                //open the connection
                conn.Open();

                //run the delete and store the number of records effected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Deleted";
            }

            catch (Exception err)
            {
                strResult = "Error: " + err.Message; //Set feedback
            }

            finally
            {
                //Close the connection
                conn.Close(); 
            }
            return strResult;

        }

        public string UpdateARecord()
        {
            Int32 intRecords = 0;
            string strResult = "";

            //Create SQL commad string
            string strSQL = "UPDATE EProduct2 SET Brand=@Brand, Model=@Model, Category=@Category, Description=@Description, Price=@Price, ReleaseDate=@ReleaseDate, Quantity=@Quantity, Weight=@Weight, Active=@Active WHERE ProductID = @ProductID";

            //Create a connection to DB
            SqlConnection conn = new SqlConnection();
            //Cerate the who, what where of the DB
            string strConn = GetConnected();
            conn.ConnectionString = strConn;

            //Bark out commands
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //commander knows what to say
            comm.Connection = conn;

            //fill in the parameters (has to be created in same sequence as they are used in SQL statement)
            comm.Parameters.AddWithValue("@Brand", Brand);
            comm.Parameters.AddWithValue("@Model", Model);
            comm.Parameters.AddWithValue("@Category", Category);
            comm.Parameters.AddWithValue("@Description", Description);
            comm.Parameters.AddWithValue("@Price", Price);
            comm.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            comm.Parameters.AddWithValue("@Quantity", Quantity);
            comm.Parameters.AddWithValue("@Weight", Weight);
            comm.Parameters.AddWithValue("@Active", Active);
            comm.Parameters.AddWithValue("@ProductID", ProductID);

            try
            {
                //Open the connection
                conn.Open();

                //run the update and store thenumber of records effected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Updated.";
            }
            catch (Exception err)
            {
                strResult = "Error: " + err.Message;       //set feedback to state there was an error and error info
            }
            finally
            {
                //close the connection
                conn.Close();
            }
            return strResult;

        }

    }
}
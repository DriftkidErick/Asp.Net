using System;
using System.Collections.Generic;
//Use namespaces to include DB capablities 
using System.Data;
using System.Data.SqlClient;
//////
using System.Linq;
using System.Web;

using Week4_Class1;

//Use these namespaces to include DataBase capablities for generic components and SQL Server

namespace SE256_Activity_ErickC.App_Code
{
    public class EBook : Book
    {
        private DateTime dateRentalExpires;
        private int bookmarkPage;

        //New - Created this var to hold EBook's ID assigned by the DataBase
        private int eBook_ID;
        
        public DateTime DateRentalExpires
        {
            get 
            {
                return dateRentalExpires;
            }
            set 
            {
                //If the date given is a future date
                if (ValidationLibrary.IsAFutureDate(value))
                {
                    dateRentalExpires = value; //Past date store it
                }

                else
                {
                    //Future dates cause error messages
                    feedback += "ERROR: You must enter future dates";
                }
            }
        }

        public int BookmarkPage
        {
            get 
            {
                return bookmarkPage;
            }

            set
            {
                //If bookmark pages are greater/ equal to 0 but less a than pages store the book
                if (value >= 0 && value <= Pages)
                {
                    bookmarkPage = value; //Store pages
                }
                else
                {
                    feedback += "ERROR: Sorry you entered an invalid page # for a bookmark.";
                }
            }
        }

        public Int32 EBook_ID
        {
            get
            {
                return eBook_ID;
            }

            set 
            {
                //If we have the minimum number of pages
                if (value >= 0)
                {
                    eBook_ID = value; //Store the # of pages
                }

                else
                {
                    //Store an error message 
                    feedback += "ERROR: Sorry you entered an invalid EBook ID";
                }
            }
        }

        // NEW - Utility function so that one string controls all SQL Server Login Info
        private string GetConnected() //make sure to test this
        {
            return @"Server=sql.neit.edu\studentsqlserver,4500;Database=SE256_ECordon;User Id=SE256_ECordon;Password=008004507;";
        }

        //Default Constructor
        public EBook() : base() //calls the parent constuctor
        {
            BookmarkPage = 0;
            dateRentalExpires = DateTime.Now.AddDays(14);

        }

        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initiate it's properties
            Conn.ConnectionString = GetConnected(); //Who, what, where of Database

            string strSQL = "INSERT INTO EBook (Title, AuthorFirst, AuthorLast, Email, Pages, Price, DatePublished, DateRentalExpires, BookmarkPage) VALUES (@Title, @AuthorFirst, @AuthorLast, @Email, @Pages, @Price, @DatePublished, @DateRentalExpires, @BookmarkPage)";

            //Bark out command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL; //Commander knows what to say
            comm.Connection = Conn;    //Heres the phone

            //Fill in parameters
            comm.Parameters.AddWithValue("@Title", Title);
            comm.Parameters.AddWithValue("@AuthorFirst", AuthorFirst);
            comm.Parameters.AddWithValue("@AuthorLast", AuthorLast);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Pages", Pages);
            comm.Parameters.AddWithValue("@Price", Price);
            comm.Parameters.AddWithValue("@DatePublished", DatePublished);
            comm.Parameters.AddWithValue("@DateRentalExpires", DateRentalExpires);
            comm.Parameters.AddWithValue("@BookmarkPage", BookmarkPage);

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
                strResult = "ERROR: " + err.Message; //Sets feedback to state there is an error
            }

            finally
            {
                
            }

            //Return resulting feedback string
            return strResult;
        }

        //New DataSet Ver. --Part one of drill down search (take search params to narrow search)

        public DataSet SearchEBooks_DS(String strTitle, String strAuthorLast)
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();

            //Create a commmand for our SQL statement
            SqlCommand comm = new SqlCommand();

            //Write a select statement to preform search
            String strSQL = "SELECT EBookID, Title, AuthorFirst, AuthorLast, DatePublished FROM EBook WHERE 0=0";

            //If First/Last name is filled in include it as a search criteria
            if (strTitle.Length > 0)
            {
                strSQL += " And Title like @Title";
                comm.Parameters.AddWithValue("@Title", "%" + strTitle + "%");
            }

            if (strAuthorLast.Length > 0)
            {
                strSQL += " AND AuthorLast LIKE @AuthorLast";
                comm.Parameters.AddWithValue("@AuthorLast", "%" + strAuthorLast + "%");
            }

            //Create DB TOOLS and Configure
            SqlConnection conn = new SqlConnection();
            //Create the who, what, where of the DB
            String strConn = GetConnected();
            conn.ConnectionString = strConn;

            //Fill in basic info to command object
            comm.Connection = conn;    //Tell the commander what connection to use
            comm.CommandText = strSQL; //tell the command what to say 

            //Create Data Adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm; //commander needs a translator(dataAdapter) to speak with datasets

            //Get Data
            conn.Open(); //Open the connection (Pick up the phone)
            da.Fill(ds, "EBook_Temp"); //Fill the dataset with results from database and call it
            conn.Close();  //Close the connection

            return ds;
        }

        public SqlDataReader SearchEBooks_DR(String strTitle, String strAuthorLast)
        {
            //Declare a DataReader to return filled
            SqlDataReader dr;

            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();

            //Write a Select Statement to perform statement
            String strSQL = "SELECT EBookID, Title, AuthorFirst, AuthorLast, DatePublished FROM EBook WHERE 0=0";

            //If the First/Last Name is filled in Include it as a search criteria
            if (strTitle.Length > 0)
            {
                strSQL += " And Title like @Title";
                comm.Parameters.AddWithValue("@Title", "%" + strTitle + "%");
            }

            if (strAuthorLast.Length > 0)
            {
                strSQL += " AND AuthorLast LIKE @AuthorLast";
                comm.Parameters.AddWithValue("@AuthorLast", "%" + strAuthorLast + "%");
            }

            //Create DB Tools and configure

            SqlConnection conn = new SqlConnection();

            //Create the who what where when
            String strConn = GetConnected();
            conn.ConnectionString = strConn;

            //Fill in basic info to command object
            comm.Connection = conn; //Tell the commander what connection to use
            comm.CommandText = strSQL; //Tell the command what to say

            //Get Data
            conn.Open(); //Open the connection /Pick up the phone
            dr = comm.ExecuteReader(); //Fill the dataset with results from database and call it
            //conn.Close(); //Close the connection (CANNOT DO THIS OR DR IS DESTROYED

            //Return the data
            return dr;

        }

        public SqlDataReader FindOneEBook(int intEBook_ID)
        { 
            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            string strConn = GetConnected(); //My Connection String

            //My SQL command string to pull up one Ebook's data
            string sqlString = "SELECT * FROM EBook WHERE EBookID = @EBookID;";

            conn.ConnectionString = strConn; //Tell the connection object who/what/where

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@EBookID", intEBook_ID);

            //Open the Database Connection and Yell our SQL Command
            conn.Open();

            //Return Some form of feedback
            return comm.ExecuteReader(); //Return the dataset to be used by others (The calling form
        }

        public string DeleteOneEBook(int intEBook_ID)
        {
            Int32 intRecords = 0;
            string strResults = "";

            //Create and Initialize the DB Tools we Need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My SQL command string to pull up one EBook's Data
            string sqlString = "DELETE FROM EBook WHERE EBookID = @EBookID;";

            //Tell the connection object the who/what/where
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@EBookID", intEBook_ID);

            try
            {
                //Open the connection
                conn.Open();

                //Run the Delete and store the number of records effected
                intRecords = comm.ExecuteNonQuery();
                strResults = intRecords.ToString() + " Records Deleted.";
            }

            catch (Exception err) 
            {
                strResults = "Error: " + err.Message; //Set Feedback to state there was an error & error info
            }

            finally
            {
                //Close the connection
                conn.Close();
            }
            return strResults;

        }

        //New - Method to Update a record in DB

        public string UpdateARecord()
        {
            Int32 intRecords = 0;
            string strResults = "";

            //Create SQL Command String
            string strSQL = "UPDATE EBook SET Title = @Title, AuthorFirst = @AuthorFirst, AuthorLast = @AuthorLast, Email = @Email, Pages = @Pages, Price = @Price, DatePublished = @DatePublished, DateRentalExpires = @DateRentalExpires, BookmarkPage = @BookmarkPage WHERE EBookID = @EBookID;";

            //Create a connectiong to DB
            SqlConnection conn = new SqlConnection();
            //Create the who/what/where
            string strConn = GetConnected();
            conn.ConnectionString = strConn;

            //Bark out Command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL; //Knows what to say
            comm.Connection = conn; //Wheres the phone? HERE IT IS

            //Fill in the parameters
            comm.Parameters.AddWithValue("@Title", Title);
            comm.Parameters.AddWithValue("@AuthorFirst", AuthorFirst);
            comm.Parameters.AddWithValue("@AuthorLast", AuthorLast);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Pages", Pages);
            comm.Parameters.AddWithValue("@Price", Price);
            comm.Parameters.AddWithValue("@DatePublished", DatePublished);
            comm.Parameters.AddWithValue("@DateRentalExpires", DateRentalExpires);
            comm.Parameters.AddWithValue("@BookmarkPage", BookmarkPage);
            comm.Parameters.AddWithValue("@EbookID", EBook_ID);

            try
            {
                //Open the connection
                conn.Open();

                //Run the Delete and store the number of records effected
                intRecords = comm.ExecuteNonQuery();
                strResults = intRecords.ToString() + " Records Updated.";
            }

            catch (Exception err)
            {
                strResults = "Error: " + err.Message; //Set Feedback to state there was an error & error info
            }

            finally
            {
                //Close the connection
                conn.Close();
            }
            return strResults;

        }

    }
}
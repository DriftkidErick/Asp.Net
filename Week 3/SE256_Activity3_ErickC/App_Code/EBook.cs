using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Week4_Class1; //Using statement to include the validation library from a previous project

namespace SE256_Activity_ErickC.App_Code
{
    public class Book
    {
        private string title; //Title of the book
        private string authorFirst; //Author Fname
        private string authorLast; //Author Lname
        private string email; //Author's Email
        private DateTime datePublished; //Date book was published
        private int pages; //Number of pages
        private double price; //Price of book

        protected string feedback; //intended for tracking errors

        public string Title
        {
            get
            {
                return title;
            }
            set 
            {
                //Checks for bad words
                if (!ValidationLibrary.GotBadWords(value))
                {
                    title = value;
                    //If it doesn't have bad words store it
                }
                else
                {
                    feedback += "ERROR: Title has a bad word in it.";
                    //If it has bad words throw an error
                }
            }
        }

        public string AuthorFirst
        {
            get
            {
                return authorFirst;
            }
            set
            {
                //Checks for bad words
                if (!ValidationLibrary.GotBadWords(value))
                {
                    authorFirst = value;
                    //If it doesn't have bad words store it
                }
                else
                {
                    feedback += "ERROR: Title has a bad word in it.";
                    //If it has bad words throw an error
                }
            }
        }

        public string AuthorLast
        {
            get
            {
                return authorLast;
            }
            set
            {
                authorLast = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (ValidationLibrary.IsValidEmail(value))
                {
                    email = value;
                }
                else
                {
                    feedback += "ERROR: Invalid email.";
                }
            }
        }

        public DateTime DatePublished
        {
            get
            {
                return datePublished;
            }

            set
            {
                if (ValidationLibrary.IsAFutureDate(value) == false)
                {
                    datePublished = value;
                }
                else
                {
                    feedback += "ERROR: You cannot enter future dates.";
                }
            }
        }

        public int Pages
        {
            get
            {
                return pages;
            }

            set
            {
                if (ValidationLibrary.IsMinimumAmount(value, 0) == true)
                {
                    pages = value;
                }
                else 
                {
                    feedback += "ERROR: Sorry you entered an invalid # of pages.";
                }
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set 
            {
                if (ValidationLibrary.IsMinimumAmount(value, 1) == true)
                {
                    price = value;
                }
                else
                {
                    feedback += "ERROR: Price is not sufficent.";
                }
            }
        }

        //New - Allows class to communicate with outside programs
        public string Feedback 
        {
            get
            {
                //Allows outside code to see feedback
                return feedback;

                //Notice there is no set......This is because only the class can change feedback.
            } 
        }

        //New - Default Constructor - Runs automatically when object instance created
        public Book()
        {
            title = "";
            authorFirst = "";
            authorLast = "";
            pages = 0;
            datePublished = DateTime.Parse("1/1/1500");
            price = 0.0;
            feedback = "";
        }

    }
}
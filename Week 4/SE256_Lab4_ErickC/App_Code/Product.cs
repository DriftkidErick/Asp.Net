using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Week4_Class1; //This is used to call the validation lib

namespace SE256_Activity_ErickC.App_Code
{
    public class Product

    {
        private string brand;
        private string model;
        private string category;
        private string desciption;
        private double price;

        protected string feedback;


        public string Brand
        {
            get
            {
                return brand;
            }
            set 
            {
                if (!ValidationLibrary.GotBadWords(value))
                {
                    brand = value;
                }

                else
                {
                    feedback += "Error: Title has a bad word in it";
                }
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                if (!ValidationLibrary.GotBadWords(value))
                {
                    model = value;
                }

                else
                {
                    feedback += "Error: Title has a bad word in it";
                }
            }
        }

        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                if (!ValidationLibrary.GotBadWords(value))
                {
                    category = value;
                }

                else
                {
                    feedback += "Error: Title has a bad word in it";
                }
            }
        }

        public string Description
        {
            get
            {
                return desciption;
            }
            set
            {
                if (!ValidationLibrary.GotBadWords(value))
                {
                    desciption = value;
                }

                else
                {
                    feedback += "Error: Description has a bad word in it";
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
                    feedback += "Error: Price is not sufficient";
                }
            }
        }

        public string Feedback
        {
            get { return feedback; }
        }

        public Product() //Initializing so there is no Nulls
        {
            brand = "";
            model = "";
            category = "";
            desciption = "";
            price = 0.0;
            feedback = "";
        }
    }
}
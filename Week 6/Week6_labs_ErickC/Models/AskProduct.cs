using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Week6_labs_ErickC.Models
{
    //@* The Goal with the page is to allow customers to request for performace parts that are out of stock/ something we do not carry*@
    public class AskProductModel
	{

        public int Ask_ID
        {
            get; set;
        }

        public String Ask_Brand
        {
            get; set;
        }

        public String Ask_Model
        {
            get; set;
        }

        public String Ask_Category
        {
            get; set;
        }

        public int Ask_Quantity
        {
            get; set;
        }

        public String Ask_Description
        {
            get; set;
        }

        public Double Ask_Price
        {
            get; set;
        }

        public bool Ask_Active
        {
            get; set;
        }

        public String Cust_email
        {
            get; set;
        }

        public DateTime Open_Date
        {
            get; set;
        }

        public DateTime Close_Date
        {
            get; set;
        }

        public String Support_email
        {
            get; set;
        }

        public String Support_Notes
        {
            get; set;
        }

    }
}

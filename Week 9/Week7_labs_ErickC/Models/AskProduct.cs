using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using static Week6_labs_ErickC.Models.ValidationLib;
using static Week6_labs_ErickC.Models.ValidationLib.MyDateAttribute;

namespace Week6_labs_ErickC.Models
{
    //@* The Goal with the page is to allow customers to request for performace parts that are out of stock/ something we do not carry*@
    public class AskProductModel
    {

        [Required] //This will be the primary Key for the SQl table
        public int Ask_ID
        {
            get; set;
        }

        [Required, StringLength(255)]
        public String Ask_Brand

        {
            get; set;
        }

        [Required, StringLength(255)]
        public String Ask_Model
        {
            get; set;
        }

        [Required]
        [StringOptionsValidate(Allowed = new String[] { "Wheels", "Tires", "Suspention", "Preformance", "Tuning" }, ErrorMessage = "Sorry...Categories is invalid. Catergories: Wheels, Tires, Suspention, Preformance, Tuning")]
        public String Ask_Category
        {
            get; set;
        }

        [Required(ErrorMessage = "Invalid Quantity")] //Get back to this
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

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(75)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z9-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
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

        public String Feedback //Used to share FEEDBACK to users
        {
            get; set;
        }

    }
}

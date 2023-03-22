using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static TroubleTickets.Models.MyDateAttribute; //Ask Scott

namespace TroubleTickets.Models
{
    public class TroubleTicketModel
    {
        [Required]
        public int Ticket_ID
        {

            get; set;
        }

        [Required, StringLength(255)]
        public String Ticket_Title
        {
            get; set;
        }

        [Required]
        public String Ticket_Desc
        {
            get; set;
        }

        [Required] //Ask Scott about this
        [StringOptionsValidate(Allowed = new string[] { "Monitor", "Computer", "Printer", "Software Install", "Software Upgrade", "Configuration", "Internet" }, ErrorMessage = "Sorry...Category is invalid. Categories: Monitor, Computer, Printer, Software Install, Software Upgrade, Configuration, Internet")]
        public String Category
        {
            get; set;
        }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z9-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public String Reporting_Email
        {
            get; set;
        }

        [Required]
        [Display(Name = "Original date of the problem")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [MyDate(ErrorMessage = "Future data entry not allowed")]
        public DateTime Orig_Date
        {
            get; set;
        }

        [Required]
        [Display(Name = "Date of solutions/closure")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [MyDate(ErrorMessage = "Future data entry not allowed")]
        public DateTime Close_Date
        {
            get; set;
        }

        public String Responder_Notes
        {
            get; set;
        }

        
        [Required(ErrorMessage ="Email is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z9-9.-]+\.[a-z]{2,4}", ErrorMessage ="Incorrect Email Format")]
        public String Responder_Email
        {
            get; set;
        }

        [Required]
        public bool Active
        {
            get; set;
        }
    }
}

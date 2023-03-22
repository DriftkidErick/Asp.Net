using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroubleTickets.Models
{
    public class TroubleTicketModel
    {
        public int Ticket_ID
        {
            get; set;
        }

        public String Ticket_Title
        {
            get; set;
        }

        public String Ticket_Desc
        {
            get; set;
        }

        public String Category
        {
            get; set;
        }

        public String Reporting_Email
        {
            get; set;
        }

        public DateTime Orig_Date
        {
            get; set;
        }

        public DateTime Close_Date
        {
            get; set;
        }

        public String Responder_Notes
        {
            get; set;
        }

        public String Responder_Email
        {
            get; set;
        }

        public bool Active
        {
            get; set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TroubleTickets.Models;

//Added for SQL
using System.Data;
using System.Data.SqlClient;

//Added in order to use IConfig
using Microsoft.Extensions.Configuration;

//Added for session Vars
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace TroubleTickets.Models
{
    public class TicketAdmin
    {
        [Required]
        public int TicketAdmin_ID { get; set; } //Primary key

        [EmailAddress]
        [Display(Name = "Username")]
        public String TicketAdmin_Email { get; set; } //Email address of the admin/responder

        [Required, StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String TicketAdmin_PW { get; set; } //Basic 20 char pw

        public String Feedback { get; set; } //feedbac to share to user 


    }
}

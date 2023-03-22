using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Week6_labs_ErickC.Models;

using System.Data;
using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace Week6_labs_ErickC.Models
{
    public class AskAdmin
    {
        [Required]
        public int AskAdmin_ID
        { get; set; }

        [EmailAddress]
        [Display(Name = "Username")]
        public String AskAdmin_Email { get; set; }

        [Required, StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String AskAdmin_PW { get; set; }

        public String Feedback { get; set; }
    }
}

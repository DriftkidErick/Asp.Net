using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets.Models; //included this in order to create a temp ticket object

namespace TroubleTickets.Pages
{
    public class AddTicketModel : PageModel
    {
        [BindProperty]
        public TroubleTicketModel tTicket //Instance of ticket model
        {
            get; set;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            IActionResult temp; // temp var

            if (ModelState.IsValid == false) //if there is an error, point to this page
            {
                temp = Page();
            }
            else
            {
                temp = Page(); //if not errors, aim for home page
            }

            return temp;        //return the resulting IActionResult
        }
    }
}

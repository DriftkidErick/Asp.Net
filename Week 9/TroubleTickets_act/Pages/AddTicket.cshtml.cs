using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets.Models; //included this in order to create a temp ticket object

//New
//Added in order to use IConfiguration, So we can get our DB Conncetion string from the appsettings.json file

using Microsoft.Extensions.Configuration;

namespace TroubleTickets.Pages
{
    public class AddTicketModel : PageModel
    {
        [BindProperty]
        public TroubleTicketModel tTicket //Instance of ticket model
        {
            get; set;
        }

        private readonly IConfiguration _configuration; //Instance of IConfig class... allows us to read in from gonfig file like appsettings

        public AddTicketModel(IConfiguration configuration)
        {
            //Constructor code goes below
            _configuration = configuration;
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
                if (tTicket is null == false)
                {
                    TroubleTicketDataAccessLayer factory = new TroubleTicketDataAccessLayer(_configuration);

                    factory.Create(tTicket); //New runs the create function to add a record, reults in Feedback

                }
                temp = Page(); //if not errors, aim for home page
            }

            return temp;        //return the resulting IActionResult
        }
    }
}

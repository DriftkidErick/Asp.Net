using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//included to include temp ticket obj
using TroubleTickets.Models;

//Added for IConfig
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace TroubleTickets.Pages.Admin
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public TicketAdmin tAdmin { get; set; } //Instance of Admin Model
        private readonly IConfiguration _configuration; //Instance of IConfig class allows us to read in form gonFig file like appsettings

        public IndexModel(IConfiguration configuration)
        {
            //Constructor code goes below
            _configuration = configuration;
        }

        
        public void OnGet()
        {
            HttpContext.Session.SetInt32("test", 5);

        }

        //this event handler occurs when a form is posted in this page
        public IActionResult OnPost()
        {
            IActionResult temp; //Temp result var
            List<TicketAdmin> lstTicketAdmin = new List<TicketAdmin>(); //List to hold ticket admins from DB table

            if (ModelState.IsValid == false)
            {
                temp = Page();
            }

            else
            {
                if (tAdmin != null)
                {
                    TicketAdminDataAccessLayer factory = new TicketAdminDataAccessLayer(_configuration);

                    //Runs the fuction to return login search res in feedback
                    lstTicketAdmin = factory.GetAdminLogin(tAdmin).ToList();

                    if (lstTicketAdmin.Count > 0)
                    {
                        HttpContext.Session.SetInt32("TicketAdmin_ID", lstTicketAdmin[0].TicketAdmin_ID);
                        HttpContext.Session.SetString("TicketAdmin_Email", lstTicketAdmin[0].TicketAdmin_Email);

                        temp = Redirect("/Admin/ControlPanel");
                    }

                    else
                    {
                        tAdmin.Feedback = "Login Failed"; //If it failed (no record), set message and keep them here
                        temp = Page();
                    }
                }

                else
                {
                    temp = Page(); //If admin is null, then keep them here
                }
            }
            return temp; //return the resulting IAction 
        }

        
    }
}

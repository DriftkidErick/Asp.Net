using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Include these for session vars
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

using TroubleTickets.Models;

using Microsoft.Extensions.Configuration;

namespace TroubleTickets.Pages.Admin
{
    public class ControlPanelModel : PageModel
    {
        //Instacne of IConFig
        private readonly IConfiguration _configuration;

        TroubleTicketDataAccessLayer factory;
        public List<TroubleTicketModel> tix { get; set; }

        public ControlPanelModel(IConfiguration configuration)
        {
            _configuration = configuration;

            factory = new TroubleTicketDataAccessLayer(_configuration);
        }

        public IActionResult OnGet()
        {
            IActionResult temp;

            if (HttpContext.Session.GetString("TicketAdmin_Email") is null)
            {
                temp = RedirectToPage("/Admin/Index");

            }

            else
            {
                tix = factory.GetActiveRecords().ToList(); //Fill in he currently empty list with records

                temp = Page(); //else keep them here


            }

            return temp;
        }
       
    }
}

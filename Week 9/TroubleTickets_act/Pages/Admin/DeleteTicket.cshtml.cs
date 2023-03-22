using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TroubleTickets.Models;

using Microsoft.Extensions.Configuration;

namespace TroubleTickets.Pages.Admin
{
    public class DeleteTicketModel : PageModel
    {
        TroubleTicketDataAccessLayer factory;

        public TroubleTicketModel tTicket { get; set; }

        //instance of IConfig class .. allows us to read in from gonfig like appsettings
        private readonly IConfiguration _configuration;

        public DeleteTicketModel(IConfiguration configuration)
        {
            //Constructor
            _configuration = configuration;
            factory = new TroubleTicketDataAccessLayer(_configuration);
        }

        public ActionResult OnGet(int? id)
        {
            if (id == null) //if id is null Display not found
            {
                return NotFound();
            }
            tTicket = factory.GetOneRecord(id); //If Id exist send it to factory to gather info

            if (tTicket == null)  //if tTicket is null dispalt Not found
            {
                return NotFound();
            }

            return Page(); //Return the Page Data
        }

        public ActionResult OnPost(int? id)
        {
            if (id == null)  //if ID is null display not found
            {
                return NotFound();
            }

            factory.DeleteTicket(id); //Delete the record specified by id

            return RedirectToPage("/Admin/ControlPanel"); //retunr to control panel
        }

        
    }
}

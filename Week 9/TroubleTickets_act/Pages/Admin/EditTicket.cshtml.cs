using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets.Models; //included this in order to creat temp ticket obj.

using Microsoft.Extensions.Configuration;

namespace TroubleTickets.Pages.Admin
{
    public class EditTicketModel : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public TroubleTicketModel tTicket { get; set; }//instance of ticket model

        public TroubleTicketDataAccessLayer factory;

        public EditTicketModel(IConfiguration configuration)
        {
            //Constructor
            _configuration = configuration;
            factory = new TroubleTicketDataAccessLayer(_configuration);
        }

        public ActionResult OnGet(int? id)
        {
            if (id == null) //If the ID is null we will just returna  built in not found error
            {
                return NotFound();
            }
            else //Id is passed pass the id to the method which will fill tTicket
            {
                tTicket = factory.GetOneRecord(id);
            }

            if (tTicket == null) //If the ticket is null display the not found error
            {
                return NotFound();
            }

            return Page();
        }

        public ActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            factory.UpdateTicket(tTicket);
            return RedirectToPage("/Admin/ControlPanel");
            

            
        }

        
    }
}

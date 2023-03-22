using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Week6_labs_ErickC.Models;

using Microsoft.Extensions.Configuration;


namespace Week6_labs_ErickC.Pages.Admin
{
    public class EditTicketModel : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public AskProductModel aAsk { get; set; }

        public AskProductDataAccessLayer factory;

        public EditTicketModel(IConfiguration configuration)
        {
            //constructor
            _configuration = configuration;
            factory = new AskProductDataAccessLayer(_configuration);
        }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                aAsk = factory.GetOneRecord(id);
            }

            if (aAsk == null)
            {
                return NotFound();
            }

            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); //Stay here if there is an error
            }
            factory.UpdateTicket(aAsk);

            return RedirectToPage("/Admin/ControlPanel");
        }
    }
}

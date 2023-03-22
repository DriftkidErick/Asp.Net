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
    public class DeleteTicketModel : PageModel
    {
        AskProductDataAccessLayer factory;

        public AskProductModel tAsk { get; set; }

        private readonly IConfiguration _configuration;

        public DeleteTicketModel(IConfiguration configuration)
        {
            _configuration = configuration;
            factory = new AskProductDataAccessLayer(_configuration);
        }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tAsk = factory.GetOneRecord(id);

            if (tAsk == null)
            {
                return NotFound();
            }
            return Page();
        }


        public ActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            factory.DeleteTicket(id);

            return RedirectToPage("/Admin/ControlPanel");
        }

    }
}

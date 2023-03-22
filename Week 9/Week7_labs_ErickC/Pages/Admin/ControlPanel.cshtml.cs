using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

using Week6_labs_ErickC.Models;
using Microsoft.Extensions.Configuration;


namespace Week6_labs_ErickC.Pages.Admin
{
    public class ControlPanelModel : PageModel
    {
        private readonly IConfiguration _configuration;

        AskProductDataAccessLayer factory;


        public List<AskProductModel> tix { get; set; }

        public ControlPanelModel(IConfiguration configuration)
        {
            _configuration = configuration;

            factory = new AskProductDataAccessLayer(_configuration);
        }


        public IActionResult OnGet()
        {
            IActionResult temp;

            if (HttpContext.Session.GetString("AskAdmin_Email") is null)
            {
                temp = RedirectToPage("/Admin/Index");
            }
            else
            {
                tix = factory.GetActiveRecords().ToList();
                temp = Page();
            }

            return temp;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week6_labs_ErickC.Models;

using Microsoft.Extensions.Configuration;


namespace Week6_labs_ErickC.Pages
{
    public class RequestProdModel : PageModel
    {
        [BindProperty]
        public AskProductModel tAsk { get; set; } //Instance of ask model

        private readonly IConfiguration _configuration; //Instance of IConfig class allows us to read in from gonfig file like appsettings

        public RequestProdModel(IConfiguration configuration)
        {
            //Constructor goes in the code below
            _configuration = configuration;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            IActionResult temp;

            if (ModelState.IsValid == false)
            {
                temp = Page();
            }

            else
            {
                if (tAsk is null == false)
                {
                    AskProductDataAccessLayer factory = new AskProductDataAccessLayer(_configuration);

                    factory.Create(tAsk); //New runs the create function to add a new record, results in feedback
                }

                temp = Page();

            }
            return temp;
        }
    }
}

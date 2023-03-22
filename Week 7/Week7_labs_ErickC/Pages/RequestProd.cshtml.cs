using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week6_labs_ErickC.Models;


namespace Week6_labs_ErickC.Pages
{
    public class RequestProdModel : PageModel
    {
        [BindProperty]
        public AskProductModel tAsk { get; set; } //Instance of ask model
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
                temp = Page();
            }
            return temp;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroubleTickets.Pages
{
    public class IndexModel : PageModel
    {
        //BindProerety connects property with a post
        //Adding the supportGet allows data to come via URL
        [BindProperty(SupportsGet = true)]
        public String FName { get; set; }

        public void OnGet()
        {
            //If the url does not have an FName value passed, we will set default
            if (string.IsNullOrWhiteSpace(FName))
            {
                FName = "You!"; //Sets default value
            }    
        }
    }
}

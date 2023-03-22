using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Week6_labs_ErickC.Models;

using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Week6_labs_ErickC.Pages.Admin
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public AskAdmin tAdmin { get; set; }
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            //Constructor
            _configuration= configuration;
        }


        public void OnGet()
        {
            HttpContext.Session.SetInt32("test", 5);
        }

        public IActionResult OnPost()
        {
            IActionResult temp;

            List<AskAdmin>lstAskAdmin = new List<AskAdmin>();

            if (ModelState.IsValid == false)
            {
                temp = Page();
            }

            else
            {
                if (tAdmin != null)
                {
                    AskAdminDataAccessLayer factory = new AskAdminDataAccessLayer(_configuration);

                    lstAskAdmin = factory.GetAdminLogin(tAdmin).ToList();

                    if (lstAskAdmin.Count > 0)
                    {
                        HttpContext.Session.SetInt32("AskAdmin_ID", lstAskAdmin[0].AskAdmin_ID);
                        HttpContext.Session.SetString("AskAdmin_Email", lstAskAdmin[0].AskAdmin_Email);

                        temp = Redirect("/Admin/ControlPanel");
                    }
                    else
                    {
                        tAdmin.Feedback = "Login Failed";
                        temp = Page(); ;
                    }

                }

                else
                {
                    temp = Page();
                }
            }

            return temp;
        }
    }
}

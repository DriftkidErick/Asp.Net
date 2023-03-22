using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week6_labs_ErickC.Pages
{
	public class IndexModel : PageModel
	{
		//BindProperty connects property with a post
		//Adding the SupportGet allows data to come via URl
		[BindProperty(SupportsGet = true)]

		public string FName { get; set; } //First name property with default get set
		public void OnGet()
		{
			//If the URL does not have an FName value passed, we will set default
			if (string.IsNullOrWhiteSpace(FName))
			{
				FName = "You!"; //Set default value
			}
		}
	}
}

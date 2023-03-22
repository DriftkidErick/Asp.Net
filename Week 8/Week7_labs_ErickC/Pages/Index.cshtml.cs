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
	public class IndexModel : PageModel
	{
		//BindProperty connects property with a post
		//Adding the SupportGet allows data to come via URl
		[BindProperty(SupportsGet = true)]

		public string FName { get; set; } //First name property with default get set

		//Instance of IConfig
		private readonly IConfiguration _configuration;

		AskProductDataAccessLayer factory;
		public List<AskProductModel> tix
		{
			get; set;
		}

		public IndexModel(IConfiguration configuration)
		{
			_configuration = configuration;

			factory = new AskProductDataAccessLayer(_configuration);
		}



		public void OnGet()
		{
			//If the URL does not have an FName value passed, we will set default
			if (string.IsNullOrWhiteSpace(FName))
			{
				FName = "You!"; //Set default value
			}

			tix = factory.GetActiveRecords().ToList();
		}
	}
}

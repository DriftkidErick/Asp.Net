using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Necessary for Validation Attribute
using System.ComponentModel.DataAnnotations;
//Added for validation purposes (IModelValidator)
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace TroubleTickets.Models
{
    //Class pertaining to error-checking dates

    public class MyDateAttribute : ValidationAttribute
    {
        //isValid will be used to check when a date is added to see if the date is from the past/present and not from the future
        //In this scencrio the dates should not be future dates

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _dateJoin = Convert.ToDateTime(value); //Take in an object and convert to a DateTime

            if (_dateJoin <= DateTime.Now) // if date is past/present, return a Success result
            {
                return ValidationResult.Success;
            }

            else //return an error msg
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        //Class recevies an array of allowed strings. If the string passed in is within the list, WE ARE GOOD

        public class StringOptionsValidate : Attribute, IModelValidator
        {
            public string[] Allowed { get; set; } //Array of acceptable

            public string ErrorMessage { get; set; } //Error Message

            public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
            {
                if (Allowed.Contains(context.Model as string)) //if the list contains the string form Context, we are good
                {
                    return Enumerable.Empty<ModelValidationResult>();
                }

                else //Return an error Message
                { 
                    return new List<ModelValidationResult> { new ModelValidationResult("", ErrorMessage) };
                }
            }
        }
    }

    
}

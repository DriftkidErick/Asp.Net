using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Necessary for Validation Attribute
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; //Added for validation purposes

namespace Week6_labs_ErickC.Models
{
    public class ValidationLib //Here I am creating a validation Library to validate functions in this section
    {
        //Class pertaining to error checking

        public class MyDateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime _dateJoin = Convert.ToDateTime(value); //Take in an object and convert to a datetime

                if (_dateJoin <= DateTime.Now)
                {
                    return ValidationResult.Success; //If it is a past date
                }

                else
                {
                    //Error message
                    return new ValidationResult(ErrorMessage);
                }
            }

            public class StringOptionsValidate : Attribute, IModelValidator
            {
                public string[] Allowed { get; set; } //Array of acceptable string

                public string ErrorMessage { get; set; } //error message

                public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
                {
                    if (Allowed.Contains(context.Model as string))
                    {
                        return Enumerable.Empty<ModelValidationResult>();
                    }

                    else
                    {
                        //Return an error message
                        return new List<ModelValidationResult> { new ModelValidationResult("", ErrorMessage) };
                    }
                }
            }


        }


    }
}

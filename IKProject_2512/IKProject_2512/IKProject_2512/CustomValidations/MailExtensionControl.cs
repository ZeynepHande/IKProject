using IKProject_2512.Areas.Platform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.CustomValidations
{
    public class MailExtensionControl : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string extention = (string)value;

                if (extention.ToLower().Trim().Substring(0, 5) != "info@")
                {
                    return new ValidationResult("Mail adresi info@ ile başlamalıdır.");
                }
                else if (extention.ToLower().Trim().Substring(0, 5) == "info@")
                {
                    if (extention.ToLower().Trim().Substring(extention.Length - 4) != ".com")
                    {
                        return new ValidationResult("Mail adresi .com ile bitmelidir.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}

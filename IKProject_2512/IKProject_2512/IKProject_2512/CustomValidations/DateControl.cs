using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.CustomValidations
{
    public class DateControl : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime deger = (DateTime)value;

                if (deger > DateTime.Today)
                {
                    return new ValidationResult("İleri tarih girişi yapamazsınız");
                }

                return ValidationResult.Success;

            }
            return ValidationResult.Success;

        }
    }
}
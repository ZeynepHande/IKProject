using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.CustomValidations
{
    public class PlusNumber:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int deger = (int)value;

            if (deger == 0)
            {
                return new ValidationResult("Değer sıfıra eşit olamaz.");
            }
            if (deger < 0)
            {
                return new ValidationResult("Değer sıfırdan küçük olamaz!");
            }
            return ValidationResult.Success;
        }
    }
}

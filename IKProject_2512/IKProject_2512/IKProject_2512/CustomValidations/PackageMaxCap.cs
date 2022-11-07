using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.CustomValidations
{
    public class PackageMaxCap:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int deger = (int)value;
                if (deger >20000)
                {
                    return new ValidationResult("Bir pakete tanımlanabilecek kişi sayısı minimum 20 - maksimum 20.000 dir. Lütfen Bilgilerinizi kontrol edin");
                }
                if (deger < 20)
                {
                    return new ValidationResult("Bir pakete tanımlanabilecek kişi sayısı minimum 20 - maksimum 20.000 dir. Lütfen Bilgilerinizi kontrol edin");
                }
                return ValidationResult.Success;
            }
            return ValidationResult.Success;
        }
    }
}

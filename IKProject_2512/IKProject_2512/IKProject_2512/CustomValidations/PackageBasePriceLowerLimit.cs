using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.CustomValidations
{
    public class PackageBasePriceLowerLimit:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                double deger = (double)value;
                if (deger > 100000)
                {
                    return new ValidationResult("Bir pakete tanımlanabilecek maksimum fiyat 100.000,00 TL dir. Lütfen Bilgilerinizi kontrol edin");
                }
                if (deger < 1000)
                {
                    return new ValidationResult("Bir pakete tanımlanabilecek minimum fiyat 1.000,00 TL dir. Lütfen Bilgilerinizi kontrol edin");
                }
                return ValidationResult.Success;
            }
            return ValidationResult.Success;
        }
    }

}

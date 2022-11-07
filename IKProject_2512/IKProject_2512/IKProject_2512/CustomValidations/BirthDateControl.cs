using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.CustomValidations
{
    public class BirthDateControl:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime deger = (DateTime)value;

                if (18 > DateTime.Today.Year-deger.Year)
                {
                    return new ValidationResult("Girilen çalışanın yaşı 18 den küçük olamaz.");
                }
                else if (85 < DateTime.Today.Year - deger.Year)
                {
                    return new ValidationResult("Girilen çalışanın yaşı 85 ten büyük girilemez.");
                }
                else if (deger > DateTime.Today)
                {
                    return new ValidationResult("İleri tarih girişi yapamazsınız");
                }

                return ValidationResult.Success;

            }
            return ValidationResult.Success;

        }
    }
}


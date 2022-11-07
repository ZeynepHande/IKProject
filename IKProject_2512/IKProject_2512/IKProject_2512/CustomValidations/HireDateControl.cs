using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.CustomValidations
{
    public class HireDateControl:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime deger = (DateTime)value;

                if (15 <= (deger-DateTime.Now).Days) //15 günden fazla olamaz.
                {
                    return new ValidationResult("Girilen çalışan en fazla 15 gün sonra işe başlayacak olmalıdır.");
                }
                else if (50 < DateTime.Today.Year - deger.Year)
                {
                    return new ValidationResult("Girilen çalışanın işe girme tarihi 50 yıldan büyük olamaz");
                }
                //else if (deger < DateTime.Today)
                //{
                //    return new ValidationResult("İleri tarih girişi yapamazsınız");
                //}

                return ValidationResult.Success;

            }
            return ValidationResult.Success;

        }

    }
}

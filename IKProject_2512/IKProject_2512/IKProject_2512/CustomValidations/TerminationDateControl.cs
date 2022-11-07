using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.CustomValidations
{
    public class TerminationDateControl : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime deger = (DateTime)value;

                if (60 < (deger-DateTime.Today).Days) //15 günden küçük olamaz.
                {
                    return new ValidationResult("İleriye dönüş çıkış tarihi sınırı 60 gündür. Lütfen giriş bilgilerinizi tekrar kontrol edin. ");
                }

                else if (deger < DateTime.Today)
                {
                    return new ValidationResult("Geçmişe dönük çıkış tarihi belirtemezsiniz.");
                }

                return ValidationResult.Success;

            }
            return ValidationResult.Success;
        }
    }
}

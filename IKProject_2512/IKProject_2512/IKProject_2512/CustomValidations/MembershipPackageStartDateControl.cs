using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.CustomValidations
{
    public class MembershipPackageStartDateControl: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime deger = (DateTime)value;

                if (365 <  ( deger- DateTime.Today).Days)
                {
                    return new ValidationResult("Paketin başlatma tarihi 1 seneden ileri tarihe girilemez");
                }

                else if (-1>(deger- DateTime.Today).Days)
                {
                    return new ValidationResult("Geriye dönük tarih girişi yapamazsınız");
                }

                return ValidationResult.Success;

            }
            return ValidationResult.Success;

        }
    }
}

using IKProject_2512.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Models.SignUpModel
{
    public class SignUpModel:IValidatableObject
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        //[Display(Name = "Yeni Parolanız")]
        [DataType(DataType.Password)]
        [PasswordControl]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        //[Display(Name = " Yeni Parolanız Tekrar")]
        [DataType(DataType.Password)]
        [PasswordControl]
        public string LatestPassword { get; set; }

        public SignUpModel()
        {

        }
        public IEnumerable<ValidationResult>Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (this.LatestPassword != Password)
            {
               results.Add(new ValidationResult("Girdiğiniz parolalar eşleşmemektedir. Lütfen tekrar deneyin."));

            }

            return results;
        }

       
    }
}

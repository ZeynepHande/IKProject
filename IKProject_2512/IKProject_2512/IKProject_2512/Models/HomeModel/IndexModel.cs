using IKProject_2512.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Models.HomeModel
{
    public class IndexModel
    {
        [Required(ErrorMessage = "Mail Adresi alanı zorunludur.")]
        [EmailAddress]
        [Display(Name = "Mail Adresi")]
        public string MailAddress { get; set; }

        [Required(ErrorMessage = "Parola alanı zorunludur.")]
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}

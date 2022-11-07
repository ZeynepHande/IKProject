using IKProject_2512.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Models.VM_PM
{
    public class PM_Edit
    {
        public int ID { get; set; }

        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [Required(ErrorMessage = "Ad Alanı zorunludur.")]
        [Display(Name = "Adı")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [Display(Name = "İkinci Adı")]
        [DataType(DataType.Text)]
        public string MiddleName { get; set; }

        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [Required(ErrorMessage = "Soyad Alanı zorunludur.")]
        [Display(Name = "Soyadı")]
        //[DataType(DataType.Text)]
        public string Surname { get; set; }

        [EmailAddress]
        [Display(Name = "Mail Adresi")]
        [DataType(DataType.Text)]
        public string MailAddress { get; set; }


        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.DateTime)]
        [BirthDateControl]
        public DateTime BirthDate { get; set; }


        [Display(Name = "İşe Giriş Tarihi")]
        [DataType(DataType.DateTime)]
        [HireDateControl]
        public DateTime HireDate { get; set; }


        [Display(Name = "Fotoğraf Yükle")]
        public string PhotoPath { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Adres Bilgileri")]
        public string Address { get; set; }

    }
}

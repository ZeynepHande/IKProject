using IKProject_2512.CustomValidations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Areas.Platform.Models
{
    public class PlatformMgrAddModel:IValidatableObject
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
        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.DateTime)]
        [BirthDateControl]
        public DateTime? BirthDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "İşe Giriş Tarihi Alanı Zorunludur.")]
        [Display(Name = "İşe Giriş Tarihi")]
        [DataType(DataType.DateTime)]
        [HireDateControl]
        public DateTime HireDate { get; set; }

        [NotMapped]
        [Display(Name = "Fotoğraf Ekle")]
        [FileExtensions(Extensions = "jpg,jpeg,png,jfif", ErrorMessage = "Lütfen bir resim dosyası seçiniz.")]
        public IFormFile PhotoFile { get; set; }

        public string PhotoPath { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Adres Bilgileri")]
        public string Address { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "İşten Çıkış Tarihi")]
        [DataType(DataType.DateTime)]
        [TerminationDateControl]
        public DateTime? TerminationDate { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (HireDate!=default&&BirthDate!=default)
            {
                if ((this.HireDate.Year - this.BirthDate.Value.Year) < 18)
                {
                    results.Add(new ValidationResult("Personelin doğum günü ile işe giriş tarihi arasında minimum 18 sene olmalıdır. Lütfen bilgilerinizi kontrol ediniz."));
                }
            }
            if(TerminationDate!=default && HireDate != default)
            {
                if ((this.TerminationDate.Value-this.HireDate).Days<15)
                {
                    results.Add(new ValidationResult("Personelin işe giriş tarihi ile işten çıkış tarihi arasında en az 15 gün olmalıdır."));
                }
            }
           
            return results;
        }
    }
}

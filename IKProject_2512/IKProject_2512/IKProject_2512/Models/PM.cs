using IKProject_2512.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Models
{
    public class PM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public string Surname { get; set; }

        [EmailAddress]
        [Display(Name = "Mail Adresi")]
        [DataType(DataType.Text)]
        public string MailAddress { get; set; }


        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Yeni Parola")]
        [DataType(DataType.Password)]
        public string LatestPassword { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.DateTime)]
        [BirthDateControl]
        public DateTime? BirthDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "İşe Giriş Tarihi")]
        [DataType(DataType.DateTime)]
        [HireDateControl]
        public DateTime HireDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "İşten Çıkış Tarihi")]
        [DataType(DataType.DateTime)]
        [DateControl]
        public DateTime? TerminationDate { get; set; }


        [Display(Name = "Fotoğraf Yükle")]
        public string PhotoPath { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Adres Bilgileri")]
        public string Address { get; set; }

        
        public int TimeStamp { get; set; }


        public string MailExtension { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public PM()
        {
            Companies = new List<Company>();
        }

    }
}

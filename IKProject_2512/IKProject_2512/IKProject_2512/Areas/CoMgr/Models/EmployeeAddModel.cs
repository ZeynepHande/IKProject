using IKProject_2512.CustomValidations;
using IKProject_2512.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Areas.CoMgr.Models
{
    public class EmployeeAddModel : IValidatableObject
    {
        public enum ShiftType { Sabah = 0, Akşam = 1, Gece = 2 }
        [DisplayName("Personel ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; }

        [NotMapped]
        [Display(Name = "Fotoğraf Ekle")]
        //[DataType(DataType.Upload)]
         [FileExtensions(Extensions = "jpg,jpeg,png,pdf,jfif")]
        public IFormFile PhotoFile { get; set; }

        public string PhotoPath { get; set; }

        public bool IsCompanyManager { get; set; }
        public bool IsActive { get; set; }


        public virtual int? DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        [Required(ErrorMessage = "Ad Alanı zorunludur.")]
        [DisplayName("Personelin Adı")]
        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [DataType(DataType.Text)]
        public string EmployeeName { get; set; }


        [DisplayName("Personelin İkinci Adı")]
        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [DataType(DataType.Text)]
        public string EmployeeMiddleName { get; set; }


        [Required(ErrorMessage = "Soyad Alanı zorunludur.")]
        [DisplayName("Personelin Soyadı")]
        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [DataType(DataType.Text)]
        public string EmployeeLastName { get; set; }

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

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "İşten Çıkış Tarihi")]
        [DataType(DataType.DateTime)]
        [TerminationDateControl]
        public DateTime? TerminationDate { get; set; }



        [DisplayName("Görevi")]
        public string? Title { get; set; }


        [Display(Name = "Mail Adresi")]
        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }

        [RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$",
                    ErrorMessage = "Girilen telefon numarası geçerli değildir.Lütfen telefon numaranızı örnekteki gibi giriniz. Örn: 0212 222 11 00")]
        [Display(Name = "İletişim Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Display(Name = "İletişim Adresi")]
        [DataType(DataType.MultilineText)]
        public string HomeAddress { get; set; }


        [DisplayName("Çalıştığı Vardiya")]
        public ShiftType? Shift { get; set; }

        public string MailExtension
        {
            get;
            set;
        }

        public virtual Company Company { get; set; }

        [DisplayName("ŞirketID")]
        public virtual int CompanyID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (HireDate != default && BirthDate != default)
            {
                if ((this.HireDate.Year - this.BirthDate.Value.Year) < 18)
                {
                    results.Add(new ValidationResult("Personelin doğum günü ile işe giriş tarihi arasında minimum 18 sene olmalıdır. Lütfen bilgilerinizi kontrol ediniz."));
                }
            }
            if (TerminationDate != default && HireDate != default)
            {
                if ((this.TerminationDate.Value - this.HireDate).Days < 15)
                {
                    results.Add(new ValidationResult("Personelin işe giriş tarihi ile işten çıkış tarihi arasında en az 15 gün olmalıdır."));
                }
            }

            return results;
        }


        //[Required(ErrorMessage = "Parola alanı zorunludur.")]
        //[Display(Name = "Parola")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[Required(ErrorMessage = "Parola alanı zorunludur.")]
        //[Display(Name = "Parola")]
        //[DataType(DataType.Password)]
        //public string LatestPassword { get; set; }

        //public int TimeStamp { get; set; }

    }
}

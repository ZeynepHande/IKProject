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

namespace IKProject_2512.Areas.Platform.Models
{
    public class VMCoMgr
    {
        public int EmployeeID { get; set; }


        [Display(Name = "Fotoğraf Ekle")]
        public IFormFile PhotoFile { get; set; }

        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "Ad Alanı zorunludur.")]
        [DisplayName("Yöneticinin Adı")]
        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [DataType(DataType.Text)]
        public string EmployeeName { get; set; }
        [DisplayName("Yöneticinin İkinci Adı")]
        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [DataType(DataType.Text)]
        public string? EmployeeMiddleName { get; set; }
        [Required(ErrorMessage = "Soyad Alanı zorunludur.")]
        [DisplayName("Yöneticinin Soyadı")]
        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [DataType(DataType.Text)]
        public string EmployeeLastName { get; set; }
        [DisplayName("Çalıştığı Departman")]
        public string Title { get; set; }
        public virtual int? DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        [Display(Name = "Mail Adresi")]
        [DataType(DataType.EmailAddress)]
        [MailExtensionLastControl]
        public string MailAddress { get; set; }

        [RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$",
            ErrorMessage = "Girilen telefon numarası geçerli değildir.Lütfen telefon numaranızı örnekteki gibi giriniz. Örn: 0212 222 11 00")]
        [Display(Name = "İletişim Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [DisplayName("Doğum Tarihi")]
        [BirthDateControl]
        public DateTime? BirthDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [HireDateControl]
        [DisplayName("İşe Giriş Tarihi")]
        public DateTime HireDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [DateControl]
        [DisplayName("İşten Çıkış Tarihi")]
        public DateTime? TerminationDate { get; set; }
        [Display(Name = "İletişim Adresi")]
        [DataType(DataType.MultilineText)]
        public string HomeAddress { get; set; }

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

            return results;
        }

    }
}

using IKProject_2512.CustomValidations;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKProject_2512.Models
{
    public enum ShiftType { Sabah = 0, Akşam = 1, Gece = 2 }
    public class Employee
    {
        [DisplayName("Personel ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; }

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
        [DataType(DataType.DateTime)]
        [DisplayName("Doğum Tarihi")]
        [BirthDateControl]
        public DateTime? BirthDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [HireDateControl]
        [DisplayName("İşe Giriş Tarihi")]
        public DateTime? HireDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        [DateControl]
        [DisplayName("İştenÇıkış Tarihi")]
        public DateTime? TerminationDate { get; set; }



        [DisplayName("Çalıştığı Departman")]
        public string Title { get; set; }


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
        public ShiftType Shift { get; set; }


        public virtual Company Company { get; set; }

        [DisplayName("ŞirketID")]
        public virtual int CompanyID { get; set; }


        [Required(ErrorMessage = "Parola alanı zorunludur.")]
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Parola alanı zorunludur.")]
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string LatestPassword { get; set; }


        public int TimeStamp { get; set; }

        public string MailExtension
        {
            get;
            set;
        }

    }
}
using IKProject_2512.CustomValidations;
using IKProject_2512.Database;
using IKProject_2512.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Areas.Platform.Models
{
    public class CompanyEmployeeModel
    {
        [Key]
        public int CompanyID { get; set; }

        //COMPANY
        [Required(ErrorMessage = "Şirket Ad Alanı zorunludur.")]
        [Display(Name = "Şirket Adı")]
        [DataType(DataType.Text)]
        public string CompanyName { get; set; }


        [Required(ErrorMessage = "Şirket Ticari Ad Alanı zorunludur.")]
        [Display(Name = "Şirket Ticari Adı")]
        [DataType(DataType.Text)]
        public string CommercialName { get; set; }

        [RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$",
                    ErrorMessage = "Girilen telefon numarası geçerli değildir.Lütfen telefon numaranızı örnekteki gibi giriniz. Örn: 0212 222 11 00")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Şirket Adresi")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Lütfen şirketinize ait info mailini yazınız. Örn:info@bilgeadamboost.com")]
        [Display(Name = "Şirket Mail Uzantısı")]
        [MailExtensionControl]
        public string MailExtension { get; set; }

        [NotMapped]
        [Display(Name = "Şirket Fotoğrafı Ekle")]
        
        //[DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg,jpeg,png,jfif",ErrorMessage ="Lütfen bir resim dosyası seçiniz.")]
        public IFormFile PhotoFile { get; set; }

        public string PhotoPath { get; set; }

        public bool? IsActive { get; set; }

        public int JokerValue { get; set; }


        //MAIN COMPANY

        [DisplayName("Şirketin Bağlı Olduğu Üst Şirket Adı")]
        [DataType(DataType.Text)]
        public string MainCompanyName { get; set; }

        //EMPLOYEE

        [Required(ErrorMessage = "Ad Alanı zorunludur.")]
        [DisplayName("Yöneticinin Adı")]
        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [DataType(DataType.Text)]
        public string EmployeeName { get; set; }

        [DisplayName("Yöneticinin İkinci Adı")]
        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [DataType(DataType.Text)]
        public string EmployeeMiddleName { get; set; }


        [Required(ErrorMessage = "Soyad Alanı zorunludur.")]
        [DisplayName("Yöneticinin Soyadı")]
        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [DataType(DataType.Text)]
        public string EmployeeLastName { get; set; }


        //[DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        //[HireDateControl]
        //[DataType(DataType.DateTime)]
        //[DisplayName("İşe Giriş Tarihi")]
        //[Required(ErrorMessage = "İşe Giriş Tarihi Alanı zorunludur.")]
        //public DateTime HireDate { get; set; }

        //MEMBERSHIP PACKAGE
        [Required(ErrorMessage = "Üyelik Paketi Alanı zorunludur.")]
        [DisplayName("Üyelik Paket Adı")]
        public string PackageName { get; set; }


        [Required(ErrorMessage = "Lütfen paketin süresini seçiniz.")]
        [DisplayName("Üyelik Paket Süresi")]
        public MembershipPeriod PackagePeriod { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Üyelik Başlangıç Tarihi")]
        [MembershipPackageStartDateControl]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Lütfen paketin tanımlanma tarihini giriniz.")]
        public DateTime PackageStartDate { get; set; }



        public CompanyEmployeeModel()
        {

        }



    }
}

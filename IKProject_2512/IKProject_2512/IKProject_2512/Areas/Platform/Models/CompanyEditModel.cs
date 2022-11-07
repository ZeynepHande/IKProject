using IKProject_2512.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Areas.Platform.Models
{
    public class CompanyEditModel
    {
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "Şirket Alanı zorunludur.")]
        [Display(Name = "Şirket Adı")]
        [DataType(DataType.Text)]
        public string CompanyName { get; set; }


        [Display(Name = "Şirket Ticari Adı")]
        public string CommercialName { get; set; }

        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Display(Name = "Şirket Adresi")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name = "Bağlı Olduğu Üst Şirket")]
        public string MainCompanyName { get; set; }

        [Display(Name = "Logo Ekle")]
        public IFormFile PhotoFile { get; set; }

        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "Lütfen şirketinize ait mail uzantısını giriniz.")]
        [Display(Name = "Şirket Mail Uzantısı")]
        public string MailExtension { get; set; }

        [ForeignKey("CompanyPackageID")]
        public virtual int? CompanyPackageID { get; set; }

        public virtual CompanyPackage CompanyPackage { get; set; }
        [Display(Name = "Aktif Mi")]
        public bool? IsActive { get; set; }

        public int JokerValue { get; set; }

    }
}

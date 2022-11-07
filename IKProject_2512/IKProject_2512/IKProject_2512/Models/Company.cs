using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Models
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "Şirket Alanı zorunludur.")]
        [Display(Name = "Şirket Adı")]
        [DataType(DataType.Text)]
        public string CompanyName { get; set; }


        [Display(Name = "Şirket Ticari Adı")]
        public string CommercialName { get; set; }

        public int? PersonelNumber { get; set; }


        [RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$",
            ErrorMessage = "Girilen telefon numarası geçerli değildir.Lütfen telefon numaranızı örnekteki gibi giriniz. Örn: 0212 222 11 00")]
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Display(Name = "Şirket Adresi")]
        [DataType(DataType.Text)]
        public string Address { get; set; }


        public virtual int? MainCompanyID { get; set; }

        public virtual MainCompany MainCompany { get; set; }

        public virtual int? PlatformManagerID { get; set; }
        public virtual PM PlatformManager { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        [Required(ErrorMessage = "Lütfen şirketinize ait mail uzantısını giriniz.")]
        [Display(Name = "Şirket Mail Uzantısı")]
        public string MailExtension { get; set; }

        [ForeignKey("CompanyPackageID")]
        public virtual int? CompanyPackageID { get; set; }

        public virtual CompanyPackage CompanyPackage {get;set;}
        [Display(Name = "Aktif Mi")]
        public bool? IsActive { get; set; }

        public int JokerValue { get; set; }

        public Company()
        {
            Employees = new List<Employee>();
        }
        //Bir şirketin birden çok yöneticisi olabilir aynı şekilde birden çok çalışanı olabilir
    }
}

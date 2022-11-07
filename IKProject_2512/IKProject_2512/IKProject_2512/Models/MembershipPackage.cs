using IKProject_2512.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Models
{
    public class MembershipPackage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageID { get; set; }

        [RegularExpression("\\D*", ErrorMessage = "Sadece harf girebilirsiniz.")]
        [Required(ErrorMessage = " Lütfen Paket Adı Giriniz.")]
        [Display(Name = "Adı")]
        public string PackageName { get; set; }

        //[Required(ErrorMessage = " Lütfen Paketin Minimum Kapasitesini giriniz. ")]
        //[Display(Name = "Minimum Paket Kapasitesi")]
        //public int PackageMinCapacity { get; set; }

        [Required(ErrorMessage = " Lütfen Paketin Maksimum Kapasitesini giriniz. ")]
        [Display(Name = "Maksimum Paket Kapasitesi")]
        [PackageMaxCap]
        public int PackageMaxCapacity { get; set; }

        [Required(ErrorMessage = " Lütfen Paketin Başlangıç Fiyatını Giriniz ")]
        [Display(Name = "Paket Aylık Fiyatı")]
        [DataType(DataType.Currency)]
        [PackageBasePriceLowerLimit]
        public double PackageBasePrice { get; set; }

        [Display(Name = "Üyelik Paket Logosu")]
        public string PhotoPath { get; set; }
        public virtual IEnumerable<CompanyPackage> CompanyPackages { get; set; }

        public bool IsActive { get; set; }
        public MembershipPackage()
        {
            CompanyPackages = new List<CompanyPackage>();
        }
    }
}

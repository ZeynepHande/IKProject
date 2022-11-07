using IKProject_2512.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Models
{
    
    public class CompanyPackage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyPackageID { get; set; }


        public virtual Company Company { get; set; }


        public int PackageID { get; set; }
        public virtual MembershipPackage Package { get; set; }


        [DisplayName("Üyelik Süresi")]
        [Required(ErrorMessage = "Lütfen alınan paketin süresini giriniz.")]
        public MembershipPeriod MembershipMonthlyPeriod { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Üyelik Toplam Ücreti")]
        public double? MembershipPackagePrice
        {

            get
            {
                switch (MembershipMonthlyPeriod)
                {
                    case MembershipPeriod.Ay_1:
                        return Package.PackageBasePrice * 1;

                    case MembershipPeriod.Ay_6:
                        return Package.PackageBasePrice * 6*(0.9);

                    case MembershipPeriod.Ay_12:
                        return Package.PackageBasePrice * 12*(0.8);
                    default:
                        return Package.PackageBasePrice * 12 * (0.8);
                }
            }
            protected set { }
        }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Üyelik Başlangıç Tarihi")]
        [Required(ErrorMessage = "Lütfen paketin tanımlanma tarihini giriniz.")]
        [MembershipPackageStartDateControl]
        public DateTime PackageStartDate { get; set; }


        [DisplayName("Paketin Kalan Süresi")]
        public int PackageRemainingMonths
        {
            get 
            {
                switch (MembershipMonthlyPeriod)
                {
                    case MembershipPeriod.Ay_1:
                        return PackageStartDate.Month + 1- DateTime.Now.Month;
                    case MembershipPeriod.Ay_6:
                        return PackageStartDate.Month + 6 - DateTime.Now.Month;
                    case MembershipPeriod.Ay_12:
                        return PackageStartDate.Month + 12 - DateTime.Now.Month;
                    default:
                        return PackageStartDate.Month + 1 - DateTime.Now.Month;
                }
            }
            protected set { }
        }

    }
}

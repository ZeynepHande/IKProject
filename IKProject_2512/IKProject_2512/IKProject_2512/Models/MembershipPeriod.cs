using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IKProject_2512.Models
{
        public enum MembershipPeriod
        {
            [Display(Name ="1 Aylık Paket")]
            Ay_1 = 0,
            [Display(Name="6 Aylık Paket")]
            Ay_6 = 1,
            [Display(Name="12 Aylık Paket")]
            Ay_12 = 2,
        }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Models
{
    public class MainCompany
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MainCompanyID { get; set; }
        public string MainCompanyName { get; set; }
        public string CommercialName { get; set; }
        public virtual ICollection<Company> Subsidaries {get;set;}
        public MainCompany()
        {
            Subsidaries = new List<Company>();
        }
    }
}

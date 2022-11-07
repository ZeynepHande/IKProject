using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace IKProject_2512.Models
{
    public class Department
    {
        [DisplayName("Departman ID")]
        public int ID { get; set; }


        [DisplayName("Departman Kodu")]
        public string DepartmentCode { get; set; }


        [DisplayName("Departman Adı")]
        public string DepartmentName { get; set; }


        [DisplayName("Açıklama")]
        public string Notes { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new HashSet<Employee>();
        }
    }
}

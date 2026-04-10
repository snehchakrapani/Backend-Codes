using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CF_Migrations
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentDescription { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

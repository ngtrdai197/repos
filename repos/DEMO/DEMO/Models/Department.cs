using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEMO.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
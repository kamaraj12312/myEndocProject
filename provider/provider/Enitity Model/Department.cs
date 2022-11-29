using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class Department
    {
        public Department()
        {
            this.DepartmentRoles = new List<DepartmentRole>();
            this.SalesPersons = new List<SalesPerson>();
            this.UserDepartments = new List<UserDepartment>();
        }

        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool EmergencyEnabled { get; set; }
        public virtual ICollection<DepartmentRole> DepartmentRoles { get; set; }
        public virtual ICollection<SalesPerson> SalesPersons { get; set; }
        public virtual ICollection<UserDepartment> UserDepartments { get; set; }
    }
}
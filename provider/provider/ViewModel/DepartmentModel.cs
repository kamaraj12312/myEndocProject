using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class DepartmentModel
    {
        public DepartmentModel()
        {
            this.DepartmentRoles = new List<DepartmentRoleModel>();
            this.UserDepartments = new List<UserDepartmentModel>();
        }

        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public bool Deleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string DepartmentTitle { get; set; }
        public string Action { get; set; }
        public bool EmergencyEnabled { get; set; }
        public string SelectedDepartment { get; set; }
        public virtual ICollection<DepartmentRoleModel> DepartmentRoles { get; set; }
        public virtual ICollection<UserDepartmentModel> UserDepartments { get; set; }
    }
}
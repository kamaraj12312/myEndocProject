using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class User
    {
        public User()
        {
            this.UserDepartments = new List<UserDepartment>();
            this.UserRoles = new List<UserRole>();
            this.UserDashboard = new List<UserDashboard>();
        }

        public int ID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Title { get; set; }
        public string NameLast { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string AlternatePhone { get; set; }
        public string Email { get; set; }
        public Nullable<int> EmailConfirmed { get; set; }
        public string Comments { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string AccountType { get; set; }
        public string AccountID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public int LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string CompanyName { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool EmergencyEnabled { get; set; }
        public virtual ICollection<UserDepartment> UserDepartments { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserDashboard> UserDashboard { get; set; }

        public string DownloadFilePassword { get; set; }
    }
}
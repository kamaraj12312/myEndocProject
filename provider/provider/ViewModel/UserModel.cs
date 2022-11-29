using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class UserModel
    {
        public UserModel()
        {
            this.UserRoles = new List<UserRoleModel>();
            this.SalesPersons = new List<SalesPersonModel>();
            this.Dashboards = new List<DashboardModel>();
        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string ConfirmUserName { get; set; }
        public string PasswordHash { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool EmailAddressAsUserName { get; set; }
        public bool TermsAndCondition { get; set; }
        public bool Rememberme { get; set; }
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
        public string CompanyName { get; set; }
        public Nullable<int> EmailConfirmed { get; set; }
        public string Comments { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string AccountType { get; set; }
        public bool Deleted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public int LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public virtual ICollection<UserRoleModel> UserRoles { get; set; }
        public bool EmergencyEnabled { get; set; }

        // public Nullable<int> SalutationID { get; set; }

        public virtual ICollection<SalesPersonModel> SalesPersons { get; set; }

        public virtual ICollection<DashboardModel> Dashboards { get; set; }

        public string DownloadFilePassword { get; set; }


        #region PageList Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion

        #region Custom Property

        public bool UserRadioButton { get; set; }
        public bool ProviderRadioButton { get; set; }
        public bool PatientRadioButton { get; set; }

        public string AccountID { get; set; }
        public string UserTitle { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public string MenuActionLink { get; set; }
        public string MainIconPath { get; set; }
        public string ScreenDescription { get; set; }
        public string ActionLink { get; set; }
        public string SubIconPath { get; set; }
        public string SubScreenDescription { get; set; }
        public int ModuleDisplayOrder { get; set; }
        public int ScreenDisplayOrder { get; set; }
        public int SubScreenDisplayOrder { get; set; }
        public int SubScreenIndex { get; set; }
        public string JSFunction { get; set; }
        public string ClientName { get; set; }
        public string ShortName { get; set; }
        #endregion
    }
}
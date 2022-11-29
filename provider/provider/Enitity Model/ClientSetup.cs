using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class ClientSetup
    {
        public ClientSetup()
        {
            this.Bills = new List<Bill>();
            this.ClientAccountSetups = new List<ClientAccountSetup>();
            this.ClientAddressSetups = new List<ClientAddressSetup>();
            this.ClientContactPersonSetups = new List<ClientContactPersonSetup>();
            this.UserActivations = new List<UserActivation>();
        }

        public int ClientSetupID { get; set; }
        public string ClientNo { get; set; }
        public string ClientName { get; set; }
        public string DisplayName { get; set; }
        public string ShortName { get; set; }
        public string ClientSchema { get; set; }
        public Nullable<int> StatusID { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Connection { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<ClientAccountSetup> ClientAccountSetups { get; set; }
        public virtual ICollection<ClientAddressSetup> ClientAddressSetups { get; set; }
        public virtual ICollection<ClientContactPersonSetup> ClientContactPersonSetups { get; set; }
        public virtual ICollection<UserActivation> UserActivations { get; set; }
        //public virtual ICollection<SchemaMaster> SchemaMasters { get; set; }
    }
}
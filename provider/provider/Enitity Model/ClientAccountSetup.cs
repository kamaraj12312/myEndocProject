using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class ClientAccountSetup
    {
        public ClientAccountSetup()
        {
            this.Bills = new List<Bill>();
        }

        public int ID { get; set; }
        public int ClientAccountID { get; set; }
        public string ProductID { get; set; }
        public int ClientSetupID { get; set; }
        public Nullable<System.DateTime> ActivateFrom { get; set; }
        public Nullable<System.DateTime> ActivateTo { get; set; }
        public Nullable<int> NoOfProvider { get; set; }
        public Nullable<int> StatusID { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ClientSetup ClientSetup { get; set; }
        public virtual Product Product { get; set; }
    }
}
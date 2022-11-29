using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class Product
    {
        public Product()
        {
            this.Bills = new List<Bill>();
            this.ClientAccountSetups = new List<ClientAccountSetup>();
        }

        public int ID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int NoOfProvider { get; set; }
        public int NoOfUser { get; set; }
        public int NoOfMember { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountRate { get; set; }
        public Nullable<int> PlanRoleSetupID { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<ClientAccountSetup> ClientAccountSetups { get; set; }

        public virtual ICollection<ProductRole> ProductRoles { get; set; }
        public virtual PlanRoleSetup PlanRoleSetup { get; set; }
    }
}
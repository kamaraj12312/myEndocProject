using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.Enitity_Model
{
    public class ModuleSetup
    {
        public ModuleSetup()
        {
            this.FieldConfigurations = new List<FieldConfiguration>();
            this.ScreenSetups = new List<ScreenSetup>();
            this.ViewModelSetups = new List<ViewModelSetup>();
            this.ScreenSetups1 = new List<ScreenSetup>();
        }

        public int ID { get; set; }
        public int ModuleSetupID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public string MenuActionLink { get; set; }
        public string MainIconPath { get; set; }
        public string SubIconPath { get; set; }
        public string SideMenuIconPath { get; set; }
        public Nullable<bool> IsVisible { get; set; }
        public Nullable<bool> ShowInSideMenu { get; set; }
        public bool Deleted { get; set; }
        public Nullable<int> ProjectSetupID { get; set; }
        public virtual ICollection<FieldConfiguration> FieldConfigurations { get; set; }
        public virtual ICollection<ScreenSetup> ScreenSetups { get; set; }
        public virtual ICollection<ViewModelSetup> ViewModelSetups { get; set; }
        public virtual ICollection<ScreenSetup> ScreenSetups1 { get; set; }
    }
}
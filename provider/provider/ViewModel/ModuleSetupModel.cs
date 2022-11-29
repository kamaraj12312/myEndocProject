using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class ModuleSetupModel
    {
        public ModuleSetupModel()
        {
            this.FieldConfigurations = new List<FieldConfigurationModel>();
            this.ScreenSetups = new List<ScreenSetupModel>();
        }

        public int ID { get; set; }
        public int ModuleSetupID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public string MenuActionLink { get; set; }
        public string MainIconPath { get; set; }
        public string SubIconPath { get; set; }
        public string ControllerName { get; set; }
        public Nullable<bool> IsVisible { get; set; }
        public bool Deleted { get; set; }
        public Nullable<int> ProjectSetupID { get; set; }
        public virtual ICollection<FieldConfigurationModel> FieldConfigurations { get; set; }
        public virtual ICollection<ScreenSetupModel> ScreenSetups { get; set; }
    }
}
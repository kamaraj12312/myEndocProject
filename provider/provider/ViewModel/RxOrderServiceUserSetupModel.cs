using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace provider.ViewModel
{
    public class RxOrderServiceUserSetupModel
    {
        #region Model Properities
        public int RxOrderServiceUserSetupID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserCredential { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        #endregion
    }
}
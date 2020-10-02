using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
    
    public class VmEnterprisePermit : ViewModelItemBase
    {
         
        public string OptionValue { get; set; }
        public int PermitTypeId { get; set; }
        public int EnterpriseProfileId { get; set; }

        public VmEnterpriseProfile EnterpriseProfile { get; set; }
        public VmPermitType PermitType { get; set; }
    }
}

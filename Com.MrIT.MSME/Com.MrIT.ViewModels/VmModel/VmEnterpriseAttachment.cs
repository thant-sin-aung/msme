using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
    
    public class VmEnterpriseAttachment : ViewModelItemBase
    { 
        
        public string Type { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int EnterpriseProfileId { get; set; }

        public VmEnterpriseProfile EnterpriseProfile { get; set; }
    }
}

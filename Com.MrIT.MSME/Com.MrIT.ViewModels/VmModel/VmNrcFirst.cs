using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
   
    public class VmNrcFirst : ViewModelItemBase
    {
       
        public string NameEng { get; set; }
        public string NameMm { get; set; }

        public List<VmEnterpriseProfile> EnterpriseProfile { get; set; }
        public List<VmNrcSecond> NrcSecond { get; set; }
    }
}

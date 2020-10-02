using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
   
    public class VmTownship : ViewModelItemBase
    {
      
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }
        public int StateRegionId { get; set; }
        public int SubAgencyId { get; set; }

        public VmStateRegion StateRegion { get; set; }
        public VmSubAgency SubAgency { get; set; }
        public List<VmEnterpriseProfile> EnterpriseProfile { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
    
    public class VmEnterprise : ViewModelItemBase
    {
    
        public string NameEng { get; set; }
        public string NameMm { get; set; }
        public int LastApprovedApplicationId { get; set; }
        public int PendingApplicationId { get; set; }
        public DateTime ExpiredOn { get; set; }
        public string Status { get; set; }
        public int SysUserId { get; set; }
        public string TinNumber { get; set; }
        public string OtherRegNo { get; set; }

        public VmSysUser SysUser { get; set; }
        public List<VmApplication> Application { get; set; }
        public List<VmEnterpriseProfile> EnterpriseProfile { get; set; }
    }
}

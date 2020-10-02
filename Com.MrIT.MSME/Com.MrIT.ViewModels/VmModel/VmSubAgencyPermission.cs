using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
    
    public class VmSubAgencyPermission : ViewModelItemBase
    {
        
        public bool IsApprover { get; set; }
        public bool IsChecker { get; set; }
        public int SubAgencyId { get; set; }
        public int SysUserId { get; set; }

        public VmSubAgency SubAgency { get; set; }
        public VmSysUser SysUser { get; set; }
    }
}

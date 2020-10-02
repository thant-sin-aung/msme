using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
   
    public class VmUserOtp : ViewModelItemBase
    { 
        public string Code { get; set; }
        public DateTime ExpiredOn { get; set; }
        public int SysUserId { get; set; }

        public VmSysUser SysUser { get; set; }
    }
}

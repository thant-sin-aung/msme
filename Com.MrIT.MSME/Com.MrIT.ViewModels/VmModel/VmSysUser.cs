using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
    
    public class VmSysUser : ViewModelItemBase
    {
        
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSuper { get; set; }
        public bool IsAgency { get; set; }
        public bool IsSubAgency { get; set; }
        public bool IsViewOnly { get; set; }
        public bool IsBusiness { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActivated { get; set; }

        public List<VmApplication> Application { get; set; }
        public List<VmEnterprise> Enterprise { get; set; }
        public List<VmSubAgencyPermission> SubAgencyPermission { get; set; }
        public List<VmUserOtp> UserOtp { get; set; }
        public List<VmWorkflowAssignmentApprover> WorkflowAssignmentApprover { get; set; }
    }
}

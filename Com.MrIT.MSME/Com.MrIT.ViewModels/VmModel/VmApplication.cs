using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
    
    public class VmApplication : ViewModelItemBase
    {
        
      
        public string Status { get; set; }
        public string OfficialForm { get; set; }
        public string WebForm { get; set; }
        public string Certificate { get; set; }
        public decimal PayableAmount { get; set; }
        public string ApplicantSignature { get; set; }
        public int ApplicationTypeId { get; set; }
        public int EnterpriseId { get; set; }
        public int SysUserId { get; set; }
        public string CheckerComment { get; set; }

        public VmApplicationType ApplicationType { get; set; }
        public VmEnterprise Enterprise { get; set; }
        public VmSysUser SysUser { get; set; }
        public List<VmApplicationPayment> ApplicationPayment { get; set; }
        public List<VmApplicationWorkflow> ApplicationWorkflow { get; set; }
    }
}

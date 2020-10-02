using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{

    public class VmApplicationType : ViewModelItemBase
    {
       
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }
        public decimal PaymentFee { get; set; }
        public bool PaymentOption { get; set; }
        public bool NeedChecker { get; set; }
        public string OfficialTemplate { get; set; }

        public List<VmApplication> Application { get; set; }
        public List<VmWorkflowAssignment> WorkflowAssignment { get; set; }
    }
}

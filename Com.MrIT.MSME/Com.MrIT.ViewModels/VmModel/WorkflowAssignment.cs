using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
   
    public class VmWorkflowAssignment : ViewModelItemBase
    {
       
        public int Level { get; set; }
        public int SubAgencyId { get; set; }
        public int ApplicationTypeId { get; set; }

        public VmApplicationType ApplicationType { get; set; }
        public VmSubAgency SubAgency { get; set; }
        public List<VmWorkflowAssignmentApprover> WorkflowAssignmentApprover { get; set; }
    }
}

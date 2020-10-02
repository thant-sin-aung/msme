using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
   
    public class VmWorkflowAssignmentApprover : ViewModelItemBase
    {
         
        public int WorkflowAssignmentId { get; set; }
        public int SysUserId { get; set; }

        public VmSysUser SysUser { get; set; }
        public VmWorkflowAssignment WorkflowAssignment { get; set; }
    }
}

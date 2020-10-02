using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("workflow_assignment_approver")]
    public class WorkflowAssignmentApprover : GenericEntity
    {
         
        public int WorkflowAssignmentId { get; set; }
        public int SysUserId { get; set; }

        public virtual SysUser SysUser { get; set; }
        public virtual WorkflowAssignment WorkflowAssignment { get; set; }
    }
}

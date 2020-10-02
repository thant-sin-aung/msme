using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("workflow_assignment")]
    public class WorkflowAssignment : GenericEntity
    {
        public WorkflowAssignment()
        {
            WorkflowAssignmentApprover = new HashSet<WorkflowAssignmentApprover>();
        }
         
        public int Level { get; set; }
        public int SubAgencyId { get; set; }
        public int ApplicationTypeId { get; set; }

        public virtual ApplicationType ApplicationType { get; set; }
        public virtual SubAgency SubAgency { get; set; }
        public virtual ICollection<WorkflowAssignmentApprover> WorkflowAssignmentApprover { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("sub_agency")]
    public class SubAgency : GenericEntity
    {
        public SubAgency()
        {
            SubAgencyPermission = new HashSet<SubAgencyPermission>();
            Township = new HashSet<Township>();
            WorkflowAssignment = new HashSet<WorkflowAssignment>();
        }
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }

        public virtual ICollection<SubAgencyPermission> SubAgencyPermission { get; set; }
        public virtual ICollection<Township> Township { get; set; }
        public virtual ICollection<WorkflowAssignment> WorkflowAssignment { get; set; }
    }
}

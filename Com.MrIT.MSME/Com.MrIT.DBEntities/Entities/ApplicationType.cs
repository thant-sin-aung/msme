using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("application_type")]
    public class ApplicationType : GenericEntity
    {
        public ApplicationType()
        {
            Application = new HashSet<Application>();
            WorkflowAssignment = new HashSet<WorkflowAssignment>();
        }

         
        public string NameEng { get; set; }
        public string NameMm { get; set; }
        public decimal PaymentFee { get; set; }
        public bool PaymentOption { get; set; }
        public bool NeedChecker { get; set; }
        public string OfficialTemplate { get; set; }

        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<WorkflowAssignment> WorkflowAssignment { get; set; }
    }
}

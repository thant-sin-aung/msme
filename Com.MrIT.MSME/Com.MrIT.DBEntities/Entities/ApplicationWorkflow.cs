using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("application_workflow")]
    public class ApplicationWorkflow : GenericEntity
    { 
        public int Level { get; set; }
        public bool ApprovalFlag { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedOn { get; set; }
        public string Comment { get; set; }
        public string ApproverSignature { get; set; }
        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }
    }
}

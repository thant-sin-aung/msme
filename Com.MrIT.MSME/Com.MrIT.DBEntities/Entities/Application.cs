using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("application")]
    public class Application : GenericEntity
    {
        public Application()
        {
            ApplicationPayment = new HashSet<ApplicationPayment>();
            ApplicationWorkflow = new HashSet<ApplicationWorkflow>();
        }

       
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

        public virtual ApplicationType ApplicationType { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public virtual SysUser SysUser { get; set; }
        public virtual ICollection<ApplicationPayment> ApplicationPayment { get; set; }
        public virtual ICollection<ApplicationWorkflow> ApplicationWorkflow { get; set; }
    }
}

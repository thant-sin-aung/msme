using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("application_payment")]
    public class ApplicationPayment : GenericEntity
    {
         
        public decimal Amount { get; set; }
        public string TransactionNumber { get; set; }
        public string Gateway { get; set; }
        public DateTime VerifiedOn { get; set; }
        public string VerifiedBy { get; set; }
        public string ManualSlip { get; set; }
        public string Status { get; set; }
        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }
    }
}

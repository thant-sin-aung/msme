using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("enterprise_permit")]
    public class EnterprisePermit : GenericEntity
    {
         
        public string OptionValue { get; set; }
        public int PermitTypeId { get; set; }
        public int EnterpriseProfileId { get; set; }

        public virtual EnterpriseProfile EnterpriseProfile { get; set; }
        public virtual PermitType PermitType { get; set; }
    }
}

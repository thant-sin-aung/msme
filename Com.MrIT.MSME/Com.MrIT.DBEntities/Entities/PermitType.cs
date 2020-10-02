using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("permit_type")]
    public class PermitType : GenericEntity
    {
        public PermitType()
        {
            EnterprisePermit = new HashSet<EnterprisePermit>();
        }
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }

        public virtual ICollection<EnterprisePermit> EnterprisePermit { get; set; }
    }
}

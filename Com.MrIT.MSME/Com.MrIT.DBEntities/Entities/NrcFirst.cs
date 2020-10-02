using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("nrc_first")]
    public class NrcFirst : GenericEntity
    {
        public NrcFirst()
        {
            EnterpriseProfile = new HashSet<EnterpriseProfile>();
            NrcSecond = new HashSet<NrcSecond>();
        }
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }

        public virtual ICollection<EnterpriseProfile> EnterpriseProfile { get; set; }
        public virtual ICollection<NrcSecond> NrcSecond { get; set; }
    }
}

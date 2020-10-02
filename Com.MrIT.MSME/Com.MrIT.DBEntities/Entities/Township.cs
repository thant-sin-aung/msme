using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("township")]
    public class Township : GenericEntity
    {
        public Township()
        {
            EnterpriseProfile = new HashSet<EnterpriseProfile>();
        }
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }
        public int StateRegionId { get; set; }
        public int SubAgencyId { get; set; }

        public virtual StateRegion StateRegion { get; set; }
        public virtual SubAgency SubAgency { get; set; }
        public virtual ICollection<EnterpriseProfile> EnterpriseProfile { get; set; }
    }
}

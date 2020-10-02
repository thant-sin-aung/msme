using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("state_region")]
    public class StateRegion : GenericEntity
    {
        public StateRegion()
        {
            EnterpriseProfile = new HashSet<EnterpriseProfile>();
            Township = new HashSet<Township>();
        }
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }

        public virtual ICollection<EnterpriseProfile> EnterpriseProfile { get; set; }
        public virtual ICollection<Township> Township { get; set; }
    }
}

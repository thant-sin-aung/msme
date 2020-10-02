using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("sector")]
    public class Sector : GenericEntity
    {
        public Sector()
        {
            EnterpriseProfile = new HashSet<EnterpriseProfile>();
        }
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }

        public virtual ICollection<EnterpriseProfile> EnterpriseProfile { get; set; }
    }
}

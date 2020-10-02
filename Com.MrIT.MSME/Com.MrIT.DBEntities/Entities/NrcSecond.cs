using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("nrc_second")]
    public class NrcSecond : GenericEntity
    {
        public NrcSecond()
        {
            EnterpriseProfile = new HashSet<EnterpriseProfile>();
        }
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }
        public int NrcFirstId { get; set; }

        public virtual NrcFirst NrcFirst { get; set; }
        public virtual ICollection<EnterpriseProfile> EnterpriseProfile { get; set; }
    }
}

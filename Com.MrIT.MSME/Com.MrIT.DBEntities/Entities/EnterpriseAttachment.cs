using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("enterprise_attachment")]
    public class EnterpriseAttachment : GenericEntity
    { 
        
        public string Type { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int EnterpriseProfileId { get; set; }

        public virtual EnterpriseProfile EnterpriseProfile { get; set; }
    }
}

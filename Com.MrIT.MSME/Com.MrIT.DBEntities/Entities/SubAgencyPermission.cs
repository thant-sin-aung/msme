using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("sub_agency_permission")]
    public class SubAgencyPermission : GenericEntity
    {
        
        public bool IsApprover { get; set; }
        public bool IsChecker { get; set; }
        public int SubAgencyId { get; set; }
        public int SysUserId { get; set; }

        public virtual SubAgency SubAgency { get; set; }
        public virtual SysUser SysUser { get; set; }
    }
}

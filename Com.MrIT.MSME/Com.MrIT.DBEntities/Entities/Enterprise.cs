using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("enterprise")]
    public class Enterprise : GenericEntity
    {
        public Enterprise()
        {
            Application = new HashSet<Application>();
            EnterpriseProfile = new HashSet<EnterpriseProfile>();
        }
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }
        public int LastApprovedApplicationId { get; set; }
        public int PendingApplicationId { get; set; }
        public DateTime ExpiredOn { get; set; }
        public string Status { get; set; }
        public int SysUserId { get; set; }
        public string TinNumber { get; set; }
        public string OtherRegNo { get; set; }

        public virtual SysUser SysUser { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<EnterpriseProfile> EnterpriseProfile { get; set; }
    }
}

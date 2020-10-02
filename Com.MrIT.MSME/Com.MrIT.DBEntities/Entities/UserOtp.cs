using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("user_otp")]
    public class UserOtp : GenericEntity
    { 
        public string Code { get; set; }
        public DateTime ExpiredOn { get; set; }
        public int SysUserId { get; set; }

        public virtual SysUser SysUser { get; set; }
    }
}

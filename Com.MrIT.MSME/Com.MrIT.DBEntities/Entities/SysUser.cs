using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("sys_user")]
    public class SysUser : GenericEntity
    {
        public SysUser()
        {
            Application = new HashSet<Application>();
            Enterprise = new HashSet<Enterprise>();
            SubAgencyPermission = new HashSet<SubAgencyPermission>();
            UserOtp = new HashSet<UserOtp>();
            WorkflowAssignmentApprover = new HashSet<WorkflowAssignmentApprover>();
        }
         
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsSuper { get; set; }
        public bool IsAgency { get; set; }
        public bool IsSubAgency { get; set; }
        public bool IsViewOnly { get; set; }
        public bool IsBusiness { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActivated { get; set; }

        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Enterprise> Enterprise { get; set; }
        public virtual ICollection<SubAgencyPermission> SubAgencyPermission { get; set; }
        public virtual ICollection<UserOtp> UserOtp { get; set; }
        public virtual ICollection<WorkflowAssignmentApprover> WorkflowAssignmentApprover { get; set; }
    }
}

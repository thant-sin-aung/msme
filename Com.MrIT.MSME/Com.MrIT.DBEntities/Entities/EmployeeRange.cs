using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("employee_range")]
    public class EmployeeRange : GenericEntity
    {
        public EmployeeRange()
        {
            EnterpriseProfile = new HashSet<EnterpriseProfile>();
        }

        
        
        
        
        
        
        
        public string NameEng { get; set; }
        public string NameMm { get; set; }

        public virtual ICollection<EnterpriseProfile> EnterpriseProfile { get; set; }
    }
}

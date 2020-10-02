using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("annual_income_range")]
    public class AnnualIncomeRange : GenericEntity
    {
        public AnnualIncomeRange()
        {
            EnterpriseProfile = new HashSet<EnterpriseProfile>();
        }

        
        
        
        
        
        
        
        public string NameEng { get; set; }
        public string NameMm { get; set; }

        public virtual ICollection<EnterpriseProfile> EnterpriseProfile { get; set; }
    }
}

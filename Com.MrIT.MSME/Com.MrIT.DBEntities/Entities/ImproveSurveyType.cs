using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("improve_survey_type")]
    public class ImproveSurveyType : GenericEntity
    {
        public ImproveSurveyType()
        {
            EnterpriseImproveSurvey = new HashSet<EnterpriseImproveSurvey>();
        }
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }

        public virtual ICollection<EnterpriseImproveSurvey> EnterpriseImproveSurvey { get; set; }
    }
}

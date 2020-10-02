using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("enterprise_improve_survey")]
    public class EnterpriseImproveSurvey : GenericEntity
    { 
        public string OptionValue { get; set; }
        public int ImproveSurveyTypeId { get; set; }
        public int EnterpriseProfileId { get; set; }

        public virtual EnterpriseProfile EnterpriseProfile { get; set; }
        public virtual ImproveSurveyType ImproveSurveyType { get; set; }
    }
}

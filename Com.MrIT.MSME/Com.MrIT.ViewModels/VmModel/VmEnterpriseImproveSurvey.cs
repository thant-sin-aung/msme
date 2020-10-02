using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
   
    public class VmEnterpriseImproveSurvey : ViewModelItemBase
    { 
        public string OptionValue { get; set; }
        public int ImproveSurveyTypeId { get; set; }
        public int EnterpriseProfileId { get; set; }

        public VmEnterpriseProfile EnterpriseProfile { get; set; }
        public VmImproveSurveyType ImproveSurveyType { get; set; }
    }
}

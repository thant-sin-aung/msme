﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
    
    public class VmIsoType : ViewModelItemBase
    {
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }
    }
}

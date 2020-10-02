using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("iso_type")]
    public class IsoType : GenericEntity
    {
         
        public string NameEng { get; set; }
        public string NameMm { get; set; }
    }
}

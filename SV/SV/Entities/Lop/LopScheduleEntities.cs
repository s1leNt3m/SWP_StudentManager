using SV.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SV.Entities
{
    [Table("ClassSchedule")]
    public class LopScheduleEntities : BaseEntities
    {
        public int LopId  { get; set; }
        public RankEnum Rank { get; set; }
        public SessionEnum Session { get; set; }
    }
}
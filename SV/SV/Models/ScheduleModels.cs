using SV.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SV.Models
{
    public class ScheduleModels
    {
        public int StudentId { get; set; }
        public int LopId { get; set; }
        public RankEnum Rank { get; set; }
        public SessionEnum Session { get; set; }
        public bool IsDiemDanh { get; set; }
    }
}
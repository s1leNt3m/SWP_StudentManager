using SV.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SV.Models
{
    public class UserScheduleModels
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int LopId { get; set; }
        public string LopName { get; set; }
        public RankEnum Rank { get; set; }
        public string StrRank { get; set; }
        public SessionEnum Session { get; set; }
        public string StrSession { get; set; }
    }
}
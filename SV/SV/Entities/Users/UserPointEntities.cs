using SV.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SV.Entities
{
    [Table("UserPoint")]
    public class UserPointEntities : BaseEntities
    {
        public int UserId  { get; set; }
        public PeriodEnum Period { get; set; }
        public int Year { get; set; }
        public decimal PointStudy { get; set; }
        public decimal PointGK { get; set; }
        public decimal PointCK { get; set; }
    }
}
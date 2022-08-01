using SV.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SV.Models
{
    public class UserPointModels : BaseDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public PeriodEnum Period { get; set; }
        public string Periods { get; set; }
        public int Year { get; set; }
        public decimal PointStudy { get; set; }
        public decimal PointGK { get; set; }
        public decimal PointCK { get; set; }
        public int SinhVienId { get; set; }
    }
}
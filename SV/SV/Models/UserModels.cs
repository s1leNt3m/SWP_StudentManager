using SV.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SV.Models
{
    public class UserModels : BaseDTO
    {
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class StudentModels : UserModels
    {
        public RankEnum Rank { get; set; }
        public SessionEnum Session { get; set; }
        public int LopId { get; set; }
    }
}
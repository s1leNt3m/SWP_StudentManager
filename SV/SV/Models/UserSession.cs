using SV.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SV.Models
{
    public class UserSession
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public bool IsSupperAdmin { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool RememberMe { get; set; }
        public int Id { get; set; }
        public bool IsAuthenticated { get; set; }
        public RoleEnum Role { get; set; }
    }
}
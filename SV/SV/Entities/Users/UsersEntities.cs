using SV.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SV.Entities
{
    [Table("Users")]
    public class UsersEntities : BaseEntities
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public RoleEnum Role { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
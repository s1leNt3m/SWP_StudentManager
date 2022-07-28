using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SV.Entities
{
    [Table("UserLop")]
    public class UserLopEntities : BaseEntities
    {
        public int UserId { get; set; }
        public int LopId { get; set; }
    }
}
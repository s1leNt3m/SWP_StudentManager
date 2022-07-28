using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SV.Models
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public BaseDTO()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            this.IsActive = true;
        }
    }
}
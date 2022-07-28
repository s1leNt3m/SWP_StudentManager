using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SV.Models
{
    public class LoginModels
    {
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Password { get; set; }
    }
}
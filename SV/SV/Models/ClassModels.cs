using SV.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SV.Models
{
    public class ClassModels : BaseDTO
    {
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Name { get; set; }
        public List<SelectListItem> SinhViens { get; set; }
        public List<int> SinhVienIds { get; set; }
        public int SubjectId { get; set; }
        public List<SelectListItem> Subjects { get; set; }
        public TimeLine TimeLines { get; set; }

        public RankEnum Rank { get; set; }

        public SessionEnum Session { get; set; }
        public ClassModels()
        {
            SinhViens = new List<SelectListItem>();
            Subjects = new List<SelectListItem>();
            TimeLines = new TimeLine();
        }
    }

    public class TimeLine
    {
        public bool Thu2 { get; set; }  
        public bool CheckBoxSangT2 { get; set; }
        public bool CheckBoxChieuT2 { get; set; }
        //Thứ 3
        public bool Thu3 { get; set; }
        public bool CheckBoxSangT3 { get; set; }
        public bool CheckBoxChieuT3 { get; set; }
        //Thứ 4
        public bool Thu4 { get; set; }
        public bool CheckBoxSangT4 { get; set; }
        public bool CheckBoxChieuT4 { get; set; }
        //Thứ 5
        public bool Thu5 { get; set; }
        public bool CheckBoxSangT5 { get; set; }
        public bool CheckBoxChieuT5 { get; set; }
        //Thứ 6
        public bool Thu6 { get; set; }
        public bool CheckBoxSangT6 { get; set; }
        public bool CheckBoxChieuT6 { get; set; }
        //Thứ 7
        public bool Thu7 { get; set; }
        public bool CheckBoxSangT7 { get; set; }
        public bool CheckBoxChieuT7 { get; set; }
        //Thứ cn
        public bool Thu0 { get; set; }
        public bool CheckBoxSangT0 { get; set; }
        public bool CheckBoxChieuT0 { get; set; }
    }

}
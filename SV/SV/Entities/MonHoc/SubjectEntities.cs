using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SV.Entities
{
    [Table("Subjects")]
    public class SubjectEntities : BaseEntities
    {
        public string Name { get; set; }
    }
}
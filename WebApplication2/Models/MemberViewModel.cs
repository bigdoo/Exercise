using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class MemberViewModel
    {

        public String Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required(ErrorMessage ="請設定有效的日期格式")]
        public DateTime Birthday { get; set; }
    }
}
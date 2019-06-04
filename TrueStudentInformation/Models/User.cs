using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrueStudentInformation.Models
{
    public class User
    {
        //用户名直接作为主键
        [Key]
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
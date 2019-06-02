using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrueStudentInformation.Models
{
    public class TrueStudent
    {
        [Key]
        public string Num { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Firstscore { get; set; }
        public int Secondscore { get; set; }
        public int Thirdscore { get; set; }
        public string Classroomid { get; set; }
    }
}
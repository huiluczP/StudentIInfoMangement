using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrueStudentInformation.Models;

namespace TrueStudentInformation.ViewModel
{
    public class StudentDetail
    {
        public string Academyname { get; set; }
        public string Classroomname { get; set; }
        public TrueStudent Stu { get; set; }
    }
}
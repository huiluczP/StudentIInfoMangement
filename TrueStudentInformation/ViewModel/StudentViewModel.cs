using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrueStudentInformation.Models;

namespace TrueStudentInformation.ViewModel
{
    //包含所有学院名称，对应的教室信息和学生信息
    public class StudentViewModel
    {
        public Classroom classroom { get; set; }
        public List<TrueStudent> students { get; set; }
    }
}
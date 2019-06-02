using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrueStudentInformation.ViewModel
{
    public class WholeInfo
    {
        public string id { get; set; }
        public List<StudentViewModel> Items { get; set; }
    }
}
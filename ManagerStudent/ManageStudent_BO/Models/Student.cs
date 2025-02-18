using System;
using System.Collections.Generic;

#nullable disable

namespace ManageStudent_BO.Models
{
    public partial class Student
    {
        public int Studentid { get; set; }
        public string Studentname { get; set; }
        public string Classname { get; set; }
        public string Academicperformance { get; set; }

        public virtual Class ClassnameNavigation { get; set; }
    }
}

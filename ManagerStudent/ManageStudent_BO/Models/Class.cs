using System;
using System.Collections.Generic;

#nullable disable

namespace ManageStudent_BO.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public string Classname { get; set; }
        public int? Studentcount { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

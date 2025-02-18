using ManageStudent_BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_Service
{
    public interface IClassService
    {
        public Class GetClassByClassName(string className);
        public List<Class> GetAllClasses();
        public bool UpdateQuanlityOfStudentInClass(Class c);
        public bool AddClass(Class c);
        public bool DeleteClass(string className);
        public List<Class> GetListClassByClassName(string className);
    }
}

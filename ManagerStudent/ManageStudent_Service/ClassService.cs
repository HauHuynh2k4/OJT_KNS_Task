using ManageStudent_BO.Models;
using ManageStudent_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_Service
{
    public class ClassService : IClassService
    {
        private IClassRepo iclassrepo;
        public ClassService()
        {
            iclassrepo = new ClassRepo();
        }
        public bool AddClass(Class c)
        {
            return iclassrepo.AddClass(c);
        }

        public bool DeleteClass(string className)
        {
            return iclassrepo.DeleteClass(className);
        }

        public List<Class> GetAllClasses()
        {
            return iclassrepo.GetAllClasses();
        }

        public Class GetClassByClassName(string className)
        {
            return iclassrepo.GetClassByClassName(className);
        }

        public List<Class> GetListClassByClassName(string className)
        {
            return iclassrepo.GetListClassByClassName(className);
        }

        public bool UpdateQuanlityOfStudentInClass(Class c)
        {
            return iclassrepo.UpdateQuanlityOfStudentInClass(c);
        }
    }
}

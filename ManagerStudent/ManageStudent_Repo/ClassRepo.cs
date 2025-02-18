using ManageStudent_BO.Models;
using ManageStudent_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_Repo
{
    public class ClassRepo : IClassRepo
    {
        public bool AddClass(Class c)
        {
            return ClassDAO.Instance.AddClass(c);
        }

        public bool DeleteClass(string className)
        {
            return ClassDAO.Instance.DeleteClass(className);
        }

        public List<Class> GetAllClasses()
        {
            return ClassDAO.Instance.GetAllClasses();
        }

        public Class GetClassByClassName(string className)
        {
            return ClassDAO.Instance.GetClassByClassName(className);
        }

        public List<Class> GetListClassByClassName(string className)
        {
            return ClassDAO.Instance.GetListClassByClassName(className);
        }

        public bool UpdateQuanlityOfStudentInClass(Class c)
        {
            return ClassDAO.Instance.UpdateQuanlityOfStudentInClass(c);
        }
    }
}

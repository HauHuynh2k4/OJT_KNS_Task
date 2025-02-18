using ManageStudent_BO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_DAO
{
    public class ClassDAO
    {
        private ManageStudentDemoContext DBcontext;
        private static ClassDAO instance = null;
        public static ClassDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClassDAO();

                }
                return instance;
            }
        }
        public ClassDAO()
        {
            DBcontext = new ManageStudentDemoContext();
        }
        public Class GetClassByClassName(string className) => DBcontext.Classes.SingleOrDefault(c => c.Classname == className);
        public List<Class> GetListClassByClassName(string className) => DBcontext.Classes.Where(c => string.IsNullOrEmpty(className) || c.Classname.ToLower().Contains(className.ToLower())).ToList();

        public List<Class> GetAllClasses() => DBcontext.Classes.ToList();
        public bool UpdateQuanlityOfStudentInClass(Class c) 
        {
            try
            {
                var existingClass = GetClassByClassName(c.Classname);
                if (existingClass == null)
                {
                    return false;
                }
                existingClass.Studentcount = c.Studentcount;
                DBcontext.Entry(existingClass).State = EntityState.Modified;
                return DBcontext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating class: " + ex.Message);
            }
        }
        public bool AddClass(Class c)
        {
            try
            {
                var existingClass = GetClassByClassName(c.Classname);
                if (existingClass != null)
                {
                    return false;
                }
                DBcontext.Classes.Add(c);
                return DBcontext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Adding the class: " + ex.Message);
            }
        }
        public bool DeleteClass(string className)
        {
            try
            {
                var existingClass = GetClassByClassName(className);
                if (existingClass == null)
                {
                    return false;
                }
                DBcontext.Classes.Remove(existingClass);
                return DBcontext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the class: " + ex.Message);
            }
        }
    }
}

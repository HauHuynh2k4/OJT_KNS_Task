using ManageStudent_BO.Models;
using ManageStudent_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_Repo
{
    public class StudentRepo : IStudentRepo
    {
        public bool AddStudent(Student student)
        {
            return StudentDAO.Instance.AddStudent(student);
        }

        public bool DeleteStudent(int studentID)
        {
            return StudentDAO.Instance.DeleteStudent(studentID);
        }

        public List<Student> GetAllStudents()
        {
            return StudentDAO.Instance.GetAllStudents();
        }

        public List<Student> GetAllStudentsByClassName(string ClassName)
        {
            return StudentDAO.Instance.GetAllStudentsByClassName(ClassName);
        }

        public List<Student> GetAllStudentsByPerformance(string Performance)
        {
            return StudentDAO.Instance.GetAllStudentsByPerformance(Performance);
        }

        public List<Student> GetListStudentByStudentName(string studentName)
        {
            return StudentDAO.Instance.GetListStudentByStudentName(studentName);
        }

        public Student GetStudentByStudentID(int studentID)
        {
            return StudentDAO.Instance.GetStudentByStudentID(studentID);
        }

        public Student GetStudentByStudentName(string studentName)
        {
            return StudentDAO.Instance.GetStudentByStudentName(studentName);
        }

        public bool UpdateStudentInfo(Student student)
        {
            return StudentDAO.Instance.UpdateStudentInfo(student);
        }
    }
}

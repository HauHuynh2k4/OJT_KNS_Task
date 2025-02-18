using ManageStudent_BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_Repo
{
    public interface IStudentRepo
    {
        public Student GetStudentByStudentName(string studentName);
        public Student GetStudentByStudentID(int studentID);
        public List<Student> GetListStudentByStudentName(string studentName);
        public List<Student> GetAllStudents();
        public List<Student> GetAllStudentsByClassName(string ClassName);
        public List<Student> GetAllStudentsByPerformance(string Performance);
        public bool AddStudent(Student student);
        public bool DeleteStudent(int studentID);
        public bool UpdateStudentInfo(Student student);
    }
}

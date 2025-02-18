using ManageStudent_BO.Models;
using ManageStudent_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_Service
{
    public class StudentService : IStudentService
    {
        private IStudentRepo istudentRepo;
        public StudentService()
        {
            istudentRepo = new StudentRepo();
        }

        public bool AddStudent(Student student)
        {
            return istudentRepo.AddStudent(student);
        }

        public bool DeleteStudent(int studentID)
        {
            return istudentRepo.DeleteStudent(studentID);
        }

        public List<Student> GetAllStudents()
        {
            return istudentRepo.GetAllStudents();
        }

        public List<Student> GetAllStudentsByClassName(string ClassName)
        {
            return istudentRepo.GetAllStudentsByClassName(ClassName);
        }

        public List<Student> GetAllStudentsByPerformance(string Performance)
        {
            return istudentRepo.GetAllStudentsByPerformance(Performance);
        }

        public List<Student> GetListStudentByStudentName(string studentName)
        {
            return istudentRepo.GetListStudentByStudentName(studentName);
        }

        public Student GetStudentByStudentID(int studentID)
        {
            return istudentRepo.GetStudentByStudentID(studentID);
        }

        public Student GetStudentByStudentName(string studentName)
        {
            return istudentRepo.GetStudentByStudentName(studentName);
        }

        public bool UpdateStudentInfo(Student student)
        {
            return istudentRepo.UpdateStudentInfo(student);
        }
    }
}

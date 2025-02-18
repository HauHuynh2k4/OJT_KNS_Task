using ManageStudent_BO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_DAO
{
    public class StudentDAO
    {
        private ManageStudentDemoContext DBcontext;
        private static StudentDAO instance = null;
        public static StudentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StudentDAO();

                }
                return instance;
            }
        }
        public StudentDAO()
        {
            DBcontext = new ManageStudentDemoContext();
        }
        public List<Student> GetListStudentByStudentName(string studentName) => DBcontext.Students.Where(s => string.IsNullOrEmpty(studentName) || s.Studentname.ToLower().Contains(studentName.ToLower())).ToList();
        public Student GetStudentByStudentID(int studentID) => DBcontext.Students.FirstOrDefault(s => s.Studentid.Equals(studentID));

        public Student GetStudentByStudentName(string studentName) => DBcontext.Students.FirstOrDefault(s => s.Studentname == studentName);
        public List<Student> GetAllStudents() => DBcontext.Students.ToList();
        public List<Student> GetAllStudentsByClassName(string ClassName) => DBcontext.Students.Where(s => s.Classname.Equals(ClassName)).ToList();
        public List<Student> GetAllStudentsByPerformance(string Performance) => DBcontext.Students.Where(s => s.Academicperformance.Equals(Performance)).ToList();
        public bool AddStudent(Student student)
        {
            try
            {
                var existingStudent = GetStudentByStudentID(student.Studentid);
                if (existingStudent != null)
                {
                    return false;
                }
                DBcontext.Students.Add(student);
                return DBcontext.SaveChanges() > 0;
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while Adding the Student: " + ex.Message);
            }
        }
        public bool DeleteStudent(int studentID)
        {
            try
            {
                var existingStudent = GetStudentByStudentID(studentID);
                if (existingStudent == null)
                {
                    return false;
                }
                DBcontext.Students.Remove(existingStudent);
                return DBcontext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Deleting  the Student: " + ex.Message);
            }
        }
        public bool UpdateStudentInfo(Student student)
        {
            try
            {
                var existingStudent = GetStudentByStudentName(student.Studentname);
                if (existingStudent == null)
                {
                    return false;
                }
                existingStudent.Studentname = student.Studentname;
                existingStudent.Classname = student.Classname;
                existingStudent.Academicperformance = student.Academicperformance;
                DBcontext.Entry(existingStudent).State = EntityState.Modified;
                return DBcontext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Updating  the Student: " + ex.Message);
            }
        }
    }
}

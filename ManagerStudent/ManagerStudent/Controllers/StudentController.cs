using ManageStudent_BO.Models;
using ManageStudent_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ManageStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService IstudentService;
        private readonly IClassService IClassService;
        public StudentController(IStudentService studentService,IClassService classService)
        {
            this.IstudentService = studentService;
            this.IClassService = classService;
        }
        [HttpGet("GetStudentByStudentName")]
        public IActionResult SearchStudent(string StudentName)
        {
            try
            {
                var listStudent = IstudentService.GetListStudentByStudentName(StudentName);
                if (listStudent == null)
                {
                    return NotFound("Không tìm thấy học sinh");
                }
                return Ok(listStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        [HttpGet("GetStudentByClassName")]
        public IActionResult SearchStudentByClassName(string ClassName)
        {
            try
            {
                var listStudent = IstudentService.GetAllStudentsByClassName(ClassName);
                if (listStudent == null)
                {
                    return NotFound("Không tìm thấy học sinh");
                }
                return Ok(listStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }
        [HttpPost("AddNewStudent")]
        public IActionResult AddNewStudent([FromBody] Student student)
        {
            try
            {
                if (IstudentService.AddStudent(student))
                {
                    Class c = IClassService.GetClassByClassName(student.Classname);
                    c.Studentcount++;
                    IClassService.UpdateQuanlityOfStudentInClass(c);
                    return Ok("Thêm học sinh thành công");
                }
                return BadRequest("Thêm học sinh thất bại");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }
        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(Student student)
        {
            try
            {
                if (IstudentService.DeleteStudent(student.Studentid))
                {
                    Class c = IClassService.GetClassByClassName(student.Classname);
                    c.Studentcount--;
                    IClassService.UpdateQuanlityOfStudentInClass(c);
                    return Ok("Xóa học sinh thành công");
                }
                return BadRequest("Xóa học sinh thất bại");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }
        [HttpPost("UpdateStudentInfo")]
        public IActionResult UpdateStudentInfo([FromBody] Student student)
        {
            try
            {
                Class NewClass = IClassService.GetClassByClassName(student.Classname);
                Student oldProfile = IstudentService.GetStudentByStudentID(student.Studentid);
                Class OldClass = IClassService.GetClassByClassName(oldProfile.Classname);
                if (IstudentService.UpdateStudentInfo(student))
                {
                    NewClass.Studentcount++;
                    IClassService.UpdateQuanlityOfStudentInClass(NewClass);
                    OldClass.Studentcount--;
                    IClassService.UpdateQuanlityOfStudentInClass(OldClass);
                    return Ok("Cập nhật học sinh thành công");
                }
                return BadRequest("Cập nhật học sinh thất bại");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }
        
    }
}

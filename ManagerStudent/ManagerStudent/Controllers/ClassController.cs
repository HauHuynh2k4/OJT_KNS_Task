using ManageStudent_BO.Models;
using ManageStudent_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManageStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService IclassService;
        public ClassController(IClassService IclassService)
        {
            this.IclassService = IclassService;
        }
        [HttpGet("GetAllClasses")]
        public IActionResult GetAllClasses()
        {
            List<Class> listclass = IclassService.GetAllClasses();
            if (listclass == null)
            {
                return NotFound("No class found");
            }
            return Ok(listclass);
        }
        [HttpGet("SearchClassesByClassName")]
        public IActionResult SearchClasses(string className)
        {
            List<Class> listclass = IclassService.GetListClassByClassName(className);
            if (listclass == null)
            {
                return NotFound("No class found");
            }
            return Ok(listclass);
        }
        [HttpPost("AddNewClass")]
        public IActionResult AddNewClass(Class newclass)
        {
            if (!newclass.Classname.StartsWith("Class"))
            {
                return BadRequest("Class name must start with 'Class'");
            }
            if (IclassService.GetClassByClassName(newclass.Classname) != null)
            {
                return BadRequest("Class name already exists");
            }
            if (IclassService.AddClass(newclass))
            {
                return Ok("Add class successfully");
            }
            return BadRequest("Add class failed");
        }
        [HttpDelete("DeleteClass")]
        public IActionResult DeleteClass(string className)
        {
            if (IclassService.DeleteClass(className))
            {
                return Ok("Delete class successfully");
            }
            return BadRequest("Delete class failed");
        }
    }
}

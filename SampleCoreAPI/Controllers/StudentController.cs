using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCoreAPI.Data.Interfaces;
using SampleCoreAPI.Data.Models;
using SampleCoreAPI.Data.Repositories;

namespace SampleCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudent _Students;

        public StudentController(IStudent stud)
        {
            _Students = stud;
        }

        [HttpGet]
        public async Task<List<Student>> GetAllStudents()
        {
            return await _Students.GetAllStudents();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _Students.GetStudent(id);
            if (student == null)
            {
                return BadRequest("Student not found in this branch.");
            }
            return Ok(student.StudentName);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentData(int id)
        {
            if (_Students.GetStudent(id) != null)
                return Ok(await _Students.GetStudent(id));
            else
                return NotFound();
        }

    }
}

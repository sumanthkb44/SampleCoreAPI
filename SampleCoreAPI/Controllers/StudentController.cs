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
            // Intentional conflict: different logic for merge conflict testing
            var student = await _Students.GetStudent(id);
            if (student == null)
            {
                // This message is different from other branches
                return NotFound("Student does not exist in this branch.");
            }
            // Return the whole student object instead of just the name
            return Ok(student);
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

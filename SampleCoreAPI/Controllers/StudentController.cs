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
        // Complicated conflicting code block
        [HttpPost("process")]
        public async Task<IActionResult> ProcessStudent([FromBody] Student student)
        {
            // Simulate a complicated business logic with intentional conflict
            if (student == null || string.IsNullOrWhiteSpace(student.StudentName))
            {
                // In one branch, this might throw an exception, in another, it might return BadRequest
                throw new ArgumentException("Student data is invalid."); // Conflict: Exception vs. BadRequest
            }

            // Simulate a complex calculation
            int age;
            if (!int.TryParse(student.StudentAge, out age))
            {
                // In another branch, this could log and continue, here we return error
                return BadRequest("Invalid age format.");
            }

            // Simulate a conflicting update logic
            if (age < 18)
            {
                // In one branch, this might allow underage students, in another, it blocks
                return StatusCode(StatusCodes.Status403Forbidden, "Student must be at least 18 years old.");
            }

            // Simulate a conflicting data transformation
            var processedStudent = new Student
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName.ToUpper(), // In another branch, might use ToLower()
                StudentAge = (age + 1).ToString(), // In another branch, might not increment age
                StudentCourse = student.StudentCourse
            };

            // In one branch, this might save to DB, here we just return the processed object
            return Ok(processedStudent);
        }
    }
}

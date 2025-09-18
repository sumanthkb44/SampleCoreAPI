using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCoreAPI.Data.Interfaces;
using SampleCoreAPI.Data.Models;
// using SampleCoreAPI.Data.Repositories; // This using might not be strictly necessary depending on your project structure

namespace SampleCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // Use 'readonly' for injected dependencies, it's good practice!
        private readonly IStudent _Students;

        public StudentController(IStudent stud)
        {
            _Students = stud;
        }

        /// <summary>
        /// Retrieves a list of all students.
        /// GET: api/Student
        /// </summary>
        /// <returns>A list of Student objects.</returns>
        [HttpGet]
        public async Task<List<Student>> GetAllStudents()
        {
            return await _Students.GetAllStudents();
        }

        /// <summary>
        /// Retrieves a specific student by their ID.
        /// GET: api/Student/{id}
        /// </summary>
        /// <param name="id">The ID of the student to retrieve.</param>
        /// <returns>An IActionResult containing the Student object if found, or NotFound if not.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _Students.GetStudent(id); // Fetch the student once

            if (student != null)
                return Ok(student); // Return 200 OK with the student object
            else
                return NotFound(); // Return 404 Not Found
        }

        /// <summary>
        /// Retrieves a list of students whose names contain the specified search string.
        /// GET: api/Student/byname?name={searchName}
        /// </summary>
        /// <param name="name">The partial or full name to search for.</param>
        /// <returns>A list of Student objects matching the search criteria.</returns>
        [HttpGet("byname")] // This route makes the endpoint accessible at /api/Student/byname
        public async Task<ActionResult<List<Student>>> GetStudentsByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                // If no name is provided, you might return all students or a bad request.
                // Returning all students is a common pattern if the main GET is also /api/Student
                // For this example, let's return all if the search term is empty, or you could return BadRequest.
                return await _Students.GetAllStudents();
            }

            var students = await _Students.GetStudentsByName(name);

            if (students == null || !students.Any())
            {
                return NotFound($"No students found with name containing '{name}'.");
            }

            return Ok(students);
        }
    }
}

using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCoreAPI.Data.Interfaces;
using SampleCoreAPI.Data.Models;
using SampleCoreAPI.Data.Repositories;
// using SampleCoreAPI.Data.Repositories; // This using might not be strictly necessary depending on your project structure

namespace SampleCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudent _Students;
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
            if (_Students.GetStudent(id) != null)
                return Ok(await _Students.GetStudent(id));
            var student = await _Students.GetStudent(id); // Fetch the student once

            if (student != null)
                return Ok(student); // Return 200 OK with the student object
            else
                return NotFound();
                
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            if (_Students.GetCustomer(id) != null)
                return Ok(await _Students.GetCustomer(id));
            else
                return NotFound();
        }


    }
}
  

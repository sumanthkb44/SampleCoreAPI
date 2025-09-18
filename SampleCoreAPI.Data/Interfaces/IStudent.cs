using SampleCoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleCoreAPI.Data.Interfaces
{
    public interface IStudent
    {
        Task<List<Student>> GetAllStudents();

        Task<Student> GetStudent(int id);
        Task<Student> GetCustomer(int id);
    }
}

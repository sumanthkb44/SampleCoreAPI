using SampleCoreAPI.Data.Interfaces;
using SampleCoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCoreAPI.Data.Repositories
{
    public class StudentRepositories : IStudent
    {
        private static List<Student> Stud = new List<Student>()
        {
            new Student{StudentID=1,StudentAge="25",StudentName="KB22222",StudentCourse="AZURE"},
            new Student{StudentID=2,StudentAge="26",StudentName="KBB",StudentCourse="AZUREE"},
            new Student{StudentID=3,StudentAge="27",StudentName="KBBB",StudentCourse="AZUREEE"}
        };

        public async Task<List<Student>> GetAllStudents()
        {
            return await Task.Run(() => Stud);
        }

        public async Task<Student> GetStudent(int id)
        {
            return await Task.Run(() => Stud.FirstOrDefault(x => x.StudentID == id));
        }
        public async Task<Student> GetCustomer(int id)
        {
            return await Task.Run(() => Stud.FirstOrDefault(x => x.StudentID == id));
        }
    }
}

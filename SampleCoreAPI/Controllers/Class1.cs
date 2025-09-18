using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCoreAPI.Controllers
{
    public class Employee // Renamed from Class1 for clarity
    {

        string Str = "scwewedwe";
        string name = "customer";

        // Properties to hold employee data
        public int EmployeeId { get; set; } // A unique identifier for the employee
        public string Name { get; set; }    // The employee's name (renamed from Str)
        public DateTime HireDate { get; set; } // When the employee was hired

        // Constructor to initialize an Employee object
        public Employee(int id, string name, DateTime hireDate)
        {
            EmployeeId = id;
            Name = name;
            HireDate = hireDate;
        }

        // A simple method to get the employee's details as a string
        public string GetEmployeeDetails()
        {
            return $"Employee ID: {EmployeeId}, Name: {Name}, Hired On: {HireDate.ToShortDateString()}";
        }

    }
}

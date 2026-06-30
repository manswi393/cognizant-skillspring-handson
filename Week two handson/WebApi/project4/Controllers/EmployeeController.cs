using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Hardcoded Employee List
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee
            {
                Id = 1,
                Name = "Rahul",
                Department = "IT",
                Salary = 50000
            },
            new Employee
            {
                Id = 2,
                Name = "Priya",
                Department = "HR",
                Salary = 45000
            },
            new Employee
            {
                Id = 3,
                Name = "Amit",
                Department = "Finance",
                Salary = 60000
            }
        };

        // GET All Employees
        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            return Ok(employees);
        }

        // UPDATE Employee
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            // Check Invalid Id
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            // Find Employee
            Employee emp = employees.FirstOrDefault(e => e.Id == id);

            // Employee Not Found
            if (emp == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Update Employee
            emp.Name = employee.Name;
            emp.Department = employee.Department;
            emp.Salary = employee.Salary;

            // Return Updated Employee
            return Ok(emp);
        }
    }
}
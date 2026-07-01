using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Amit", Department = "IT" },
            new Employee { Id = 2, Name = "Neha", Department = "HR" },
            new Employee { Id = 3, Name = "Raj", Department = "Finance" }
        };

        [HttpPut]
        public ActionResult<Employee> UpdateEmployee([FromBody] Employee input)
        {
            if (input.Id <= 0)
                return BadRequest("Invalid employee id");

            var emp = employees.FirstOrDefault(e => e.Id == input.Id);

            if (emp == null)
                return BadRequest("Invalid employee id");

            emp.Name = input.Name;
            emp.Department = input.Department;

            return Ok(emp);
        }
    }
}
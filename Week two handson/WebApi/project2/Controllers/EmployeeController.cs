using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee{Id=101,Name="Rahul",Department="IT",Salary=50000},
            new Employee{Id=102,Name="Sneha",Department="HR",Salary=45000},
            new Employee{Id=103,Name="Amit",Department="Finance",Salary=60000}
        };

        // GET ALL
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetEmployees()
        {
            return Ok(employees);
        }

        // GET BY ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        // POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult AddEmployee(Employee emp)
        {
            employees.Add(emp);

            return Created("", emp);
        }
    }
}
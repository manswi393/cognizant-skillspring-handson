using EmployeeApi.Filters;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter]
    [ServiceFilter(typeof(CustomExceptionFilter))]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees;

        public EmployeeController()
        {
            employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1995,5,20),

                    Department = new Department
                    {
                        Id = 101,
                        Name = "IT"
                    },

                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Id=1,
                            Name="C#"
                        },
                        new Skill
                        {
                            Id=2,
                            Name="SQL"
                        }
                    }
                },

                new Employee
                {
                    Id = 2,
                    Name = "Alice",
                    Salary = 45000,
                    Permanent = false,
                    DateOfBirth = new DateTime(1998,8,15),

                    Department = new Department
                    {
                        Id = 102,
                        Name = "HR"
                    },

                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            Id=3,
                            Name="Communication"
                        }
                    }
                }
            };
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            // Uncomment to test exception filter

            //throw new Exception("This is custom exception.");

            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            employees.Add(employee);

            return Ok(employee);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            var emp = employees.FirstOrDefault(x => x.Id == employee.Id);

            if (emp == null)
                return NotFound();

            emp.Name = employee.Name;
            emp.Salary = employee.Salary;
            emp.Permanent = employee.Permanent;
            emp.Department = employee.Department;
            emp.Skills = employee.Skills;
            emp.DateOfBirth = employee.DateOfBirth;

            return Ok(emp);
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            string[] values =
            {
                "Value1",
                "Value2",
                "Value3"
            };

            return Ok(values);
        }

        // POST: api/values
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Data Saved Successfully");
        }

        // PUT: api/values/1
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok($"Record {id} Updated Successfully");
        }

        // DELETE: api/values/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Record {id} Deleted Successfully");
        }
    }
}
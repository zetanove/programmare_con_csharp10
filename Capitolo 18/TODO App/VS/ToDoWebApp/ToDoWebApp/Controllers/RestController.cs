using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoWebApp.Business;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {
        ITodoActivityService _service;
        public RestController(ITodoActivityService service)
        {
            _service = service;
        }

        // GET: api/Rest
        [HttpGet]
        public IEnumerable<TodoActivity> Get()
        {
            return _service.GetActivities();
        }

        // GET: api/Rest/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rest
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Rest/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

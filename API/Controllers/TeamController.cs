using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Contexts;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly AppDbContext context;

        public TeamController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/Team
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return context.Team.ToList();
        }

        // GET: api/Team/5
        [HttpGet("{id}", Name = "GetTeam")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Team
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Team/5
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

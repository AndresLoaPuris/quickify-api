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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext context;

        public AuthController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{auth}")]
        public string getAccess(string auth)
        {
            string[] values = auth.Split(";");
            if (context.Users.Any(x => x.email == values[1] && x.password == values[0]))
            {
                return "true";
            }
            else {
                return "false";
            }
        }

        [HttpGet("{auth}")]
        public string getUserExists(string auth)
        {
            string[] values = auth.Split(";");
            if (context.Users.Any(x => x.email == values[1] || x.name == values[0]))
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        [HttpGet("{authEmail}")]
        public string getNameUser(string authEmail)
        {
            return context.Users.Where(s => s.email == authEmail).FirstOrDefault().name;
        }

        [HttpPost]
        public ActionResult signUp([FromBody] Users users)
        {
           
            context.Users.Add(users);
            context.SaveChanges();
            return Ok();
        }


    }
}
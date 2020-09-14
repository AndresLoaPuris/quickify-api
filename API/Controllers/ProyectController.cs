using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Contexts;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProyectController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProyectController(AppDbContext context) {
            this.context = context;
        }

        // GET: api/Proyect/5
        [HttpGet("{email}")]
        public IEnumerable<Proyects> getProjectsByEmailFromTheUser(string email)
        {
            int id = context.Users.Where(s => s.email == email).FirstOrDefault().id;
            return context.Proyects.FromSqlRaw($"SELECT p.id , p.name , p.isDelete FROM Team e JOIN Proyects p ON e.proyect_id = p.id WHERE p.isDelete = 0 and e.user_id = {id}").ToList();
        }

        [HttpGet("{email}")]
        public string getNameUSer(string email)
        {
            return context.Users.Where(s => s.email == email).FirstOrDefault().name;
        }

        [HttpGet("{email}")]
        public IEnumerable<Users> getUsers(string email)
        {
            return context.Users.Where(s => s.email != email);
        }

        [HttpGet("{id}")]
        public string getNameProyectById(int id)
        {
            return context.Proyects.Find(id).name;
        }

        [HttpGet("{userRole}")]
        public string getRoleUserByProyect(string userRole)
        {
            string[] values = userRole.Split(";");
            int idUser = context.Users.Where(s => s.email == values[1] ).FirstOrDefault().id;
            return context.Team.Where(s => s.proyect_id == Int32.Parse(values[0]) && s.user_id == idUser).FirstOrDefault().role;
        }

        //POST: api/Proyect
        [HttpPost]
        public ActionResult addProyect([FromBody] TeamDetail teamDetail)
        {

            try
            {

                Proyects proyect = new Proyects();
                proyect.name = teamDetail.nameProyect;
                proyect.isDelete = false;
                context.Proyects.Add(proyect);
                context.SaveChanges();

                int idProyect = context.Proyects.Where(s => s.name == teamDetail.nameProyect && s.isDelete != true).FirstOrDefault().id;

                foreach (var item in teamDetail.users)
                {

                    Team equipo = new Team();
                    equipo.proyect_id = idProyect;
                    equipo.user_id = context.Users.Where(s => s.name == item.name).FirstOrDefault().id;
                    equipo.role = item.password;
                    context.Team.Add(equipo);
                    context.SaveChanges();
                }

                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT: api/Proyect/5
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

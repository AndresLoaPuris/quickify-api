using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Contexts
{
	public class AppDbContext : DbContext
	{

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{ }

		public DbSet<Proyects> Proyects { get; set; }
		public DbSet<Team> Team { get; set; }
		public DbSet<Users> Users { get; set; }
	}
}

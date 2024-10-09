using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Data
{
	public class MyAppDbContext : DbContext
	{
		public MyAppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Student> Students { get; set; }
	}
}

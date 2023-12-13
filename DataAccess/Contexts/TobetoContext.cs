using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class TobetoContext : DbContext
    {
        public TobetoContext(DbContextOptions<TobetoContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected IConfiguration Configuration { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}

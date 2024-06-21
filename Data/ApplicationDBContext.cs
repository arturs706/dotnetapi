using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace api.Data 
{
    public class ApplicationDBContext(IConfiguration configuration) : DbContext{
        protected readonly IConfiguration Configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("PSQLConn"));
        }



          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.AuthMethod)
                .HasConversion(
                    v => v.ToString(),
                    v => (AuthMethodType)Enum.Parse(typeof(AuthMethodType), v));
        }
        public DbSet<User> Users { get; set; }
    }
}
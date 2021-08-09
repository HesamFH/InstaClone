using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaClone.Models;
using Microsoft.EntityFrameworkCore;

namespace InstaClone.Data
{
    public class InstaDbContext : DbContext
    {
        public InstaDbContext(DbContextOptions<InstaDbContext> options):base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Posts> Posts { get; set; }

        public DbSet<Follow> Follows { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}

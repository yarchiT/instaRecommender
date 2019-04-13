using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Insta.Models
{
    public class InstaWebDbContext : DbContext
    {
        public DbSet<AccountInfo> AccountInfo { get; set; }
        public DbSet<Post> Posts { get; set; }
        public InstaWebDbContext (DbContextOptions<InstaWebDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.AccountInfo)
                .WithMany(b => b.Posts);
        }

       
    }
}
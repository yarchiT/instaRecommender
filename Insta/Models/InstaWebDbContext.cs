using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Insta.Models
{
// dotnet ef migrations add InitialCreate
// dotnet ef database update
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

            modelBuilder.Entity<Post>()
                .Property(e => e.HashTags)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }

       
    }
}
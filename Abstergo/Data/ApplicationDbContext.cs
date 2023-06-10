using Abstergo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Abstergo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Favorite> Links => this.Set<Favorite>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>(entity => entity.Property(x => x.Name).HasMaxLength(255));
            modelBuilder.Entity<IdentityRole>(entity => entity.Property(x => x.NormalizedName).HasMaxLength(255));
            modelBuilder.Entity<IdentityRole>(entity => entity.Property(x => x.Id).HasMaxLength(255));

            base.OnModelCreating(modelBuilder);
        }
    }
}
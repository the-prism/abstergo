using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Abstergo.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public DbSet<Folder> Folders => Set<Folder>();
        //public DbSet<Link> Links => Set<Link>();

        public DbSet<Favorite> Links => Set<Favorite>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Link>()
            //    .HasOne(b => b.Folder)
            //    .WithOne(i => i.Folder)
            //    .HasForeignKey<Folder>(b => b.Id);

            //modelBuilder.Entity<Favorite>()
            //    .HasOne(p => p.Parent)
            //    .WithOne(b => b.Parent)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
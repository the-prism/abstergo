// <copyright file="ApplicationDbContext.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// App database table context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Table of favorites
        /// </summary>
        public DbSet<Favorite> Links => this.Set<Favorite>();

        /// <summary>
        /// Table of links between favorites
        /// </summary>
        public DbSet<Link> FavoriteLinks => this.Set<Link>();

        /// <summary>
        /// Override of the model creation
        /// Define custom relations in data model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>()
                .HasOne(p => p.Favorite)
                .WithMany(b => b.Links)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Favorite>()
                .Navigation(b => b.Links)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
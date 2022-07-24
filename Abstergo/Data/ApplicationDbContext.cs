// <copyright file="ApplicationDbContext.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Data
{
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
        /// Override of the model creation
        /// Define custom relations in data model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
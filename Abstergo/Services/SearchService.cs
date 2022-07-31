// <copyright file="SearchService.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Services
{
    using Abstergo.Data;

    /// <summary>
    /// Services for searching links
    /// </summary>
    public class SearchService
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchService"/> class.
        /// </summary>
        /// <param name="context"></param>
        public SearchService(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}

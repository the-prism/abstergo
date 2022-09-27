// <copyright file="FavoriteService.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Blazor.Services
{
    using Abstergo.Blazor.Data;

    /// <summary>
    /// Services for managing favorites
    /// </summary>
    public class FavoriteService
    {
        private readonly ILogger<FavoriteService> logger;

        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FavoriteService"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public FavoriteService(ILogger<FavoriteService> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }
    }
}

// <copyright file="Index.cshtml.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Pages
{
    using Abstergo.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// View model of the index page
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;

        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        /// <summary>
        /// List of all favorite items
        /// </summary>
        public IList<Favorite> Favorites { get; set; } = default!;

        /// <summary>
        /// Function of GET request
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task OnGetAsync()
        {
            if (this.context.Links != null)
            {
                this.Favorites = await this.context.Links.Include(p => p.Links).ToListAsync();
            }
        }
    }
}
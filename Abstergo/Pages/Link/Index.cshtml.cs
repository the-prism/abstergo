// <copyright file="Index.cshtml.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Pages.Link
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abstergo.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// List all links
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="context"></param>
        public IndexModel(Abstergo.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// List of all favorite items
        /// </summary>
        public IList<Favorite> Favorite { get; set; } = default!;

        /// <summary>
        /// Async function on get request
        /// </summary>
        /// <returns>The page when the fetch from db is done</returns>
        public async Task OnGetAsync()
        {
            if (this.context.Links != null)
            {
                this.Favorite = await this.context.Links.ToListAsync();
            }
        }
    }
}

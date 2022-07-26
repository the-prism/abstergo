﻿// <copyright file="Index.cshtml.cs" company="the-prism">
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
        /// Current folder if it exists
        /// </summary>
        public Favorite? CurrentFolder { get; set; } = null;

        /// <summary>
        /// Id of the current folder
        /// </summary>
        public int FolderID { get; set; } = -1;

        /// <summary>
        /// Last order item
        /// </summary>
        public int LastOrder { get; set; }

        /// <summary>
        /// Function of GET request
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task OnGetAsync(int? id)
        {
            if (id == null && this.context.Links != null)
            {
                this.Favorites = await this.context.Links.Where(f => f.ParentID == -1).ToListAsync();
            }
            else if (this.context.Links != null)
            {
                this.Favorites = await this.context.Links.Where(f => f.ParentID == id).ToListAsync();
                this.CurrentFolder = await this.context.Links.FirstOrDefaultAsync(f => f.Id == id);
                this.FolderID = id ?? -1;
            }

            this.Favorites = this.Favorites.OrderBy(f => f.Order).ToList();
            this.LastOrder = this.Favorites.Last().Order;
        }
    }
}
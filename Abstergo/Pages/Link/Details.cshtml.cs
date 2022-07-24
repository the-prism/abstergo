// <copyright file="Details.cshtml.cs" company="the-prism">
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
    /// Display a link details
    /// </summary>
    public class DetailsModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailsModel"/> class.
        /// </summary>
        /// <param name="context"></param>
        public DetailsModel(Abstergo.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// The favorite item to display
        /// </summary>
        public Favorite Favorite { get; set; } = default!;

        /// <summary>
        /// On page get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || this.context.Links == null)
            {
                return this.NotFound();
            }

            var favorite = await this.context.Links.FirstOrDefaultAsync(m => m.Id == id);

            if (favorite == null)
            {
                return this.NotFound();
            }
            else
            {
                this.Favorite = favorite;
            }

            return this.Page();
        }
    }
}

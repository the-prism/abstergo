// <copyright file="Delete.cshtml.cs" company="the-prism">
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
    /// Data model for the delete page of link
    /// </summary>
    public class DeleteModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteModel"/> class.
        /// </summary>
        /// <param name="context"></param>
        public DeleteModel(Abstergo.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Favorite to delete
        /// </summary>
        [BindProperty]
        public Favorite Favorite { get; set; } = default!;

        /// <summary>
        /// On GET request of the delete page
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

        /// <summary>
        /// On delete POST request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || this.context.Links == null)
            {
                return this.NotFound();
            }

            var favorite = await this.context.Links.FirstOrDefaultAsync(m => m.Id == id);

            if (favorite != null)
            {
                this.Favorite = favorite;
                this.context.Links.Remove(this.Favorite);
                await this.context.SaveChangesAsync();
            }

            return this.RedirectToPage("./Index");
        }
    }
}

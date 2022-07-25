// <copyright file="Edit.cshtml.cs" company="the-prism">
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
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// View model of the edit page
    /// </summary>
    public class EditModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditModel"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EditModel(Abstergo.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Favorite item to edit
        /// </summary>
        [BindProperty]
        public Favorite Favorite { get; set; } = default!;

        /// <summary>
        /// On GET request of the page
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

            this.Favorite = favorite;
            return this.Page();
        }

        /// <summary>
        /// On POST of the form to edit the favorite
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see https://aka.ms/RazorPagesCRUD.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            this.context.Attach(this.Favorite).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.FavoriteExists(this.Favorite.Id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.RedirectToPage("./Index");
        }

        private bool FavoriteExists(int id)
        {
            return (this.context.Links?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

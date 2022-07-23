// <copyright file="Create.cshtml.cs" company="the-prism">
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
    using Microsoft.Extensions.Primitives;
    using Links = Abstergo.Data.Link;

    /// <summary>
    /// Link creation view model page
    /// </summary>
    public class CreateModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateModel"/> class.
        /// </summary>
        /// <param name="context"></param>
        public CreateModel(Abstergo.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// New favortie to be created
        /// </summary>
        [BindProperty]
        public Favorite Favorite { get; set; } = default!;

        /// <summary>
        /// List of all the existing favorites
        /// </summary>
        public IList<Favorite> Favorites { get; set; } = default!;

        /// <summary>
        /// List of the existing favorites id for display
        /// </summary>
        public List<int> Links { get; set; } = new List<int>();

        /// <summary>
        /// On display of the creation page
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            if (this.context.Links != null)
            {
                this.Favorites = await this.context.Links.ToListAsync();
            }

            foreach (var entry in this.Favorites)
            {
                this.Links.Add(entry.Id);
            }

            return this.Page();
        }

        /// <summary>
        /// On form submit
        /// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid || this.context.Links == null || this.Favorite == null)
            {
                return this.Page();
            }

            // Get the existing favorites
            this.Favorites = await this.context.Links.ToListAsync();

            // Create the new one
            this.context.Links.Add(this.Favorite);
            await this.context.SaveChangesAsync();

            // Get the list of child and add them to the newley created folder
            var folderContent = this.Request.Form["Content"];
            var newFav = this.PrepareFolderContents(this.Favorite, folderContent);
            this.context.Attach(newFav).State = EntityState.Modified;

            await this.context.SaveChangesAsync();

            return this.RedirectToPage("./Index");
        }

        /// <summary>
        /// Prepare the links for a favorite item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="contents"></param>
        /// <returns>The updated favorite with links</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private Favorite PrepareFolderContents(Favorite item, StringValues contents)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            int idParent = item.Id;

            foreach (var itemContent in contents)
            {
                item.Links.Add(new Links() { ParentId = idParent, ChildId = int.Parse(itemContent) });
            }

            return item;
        }
    }
}

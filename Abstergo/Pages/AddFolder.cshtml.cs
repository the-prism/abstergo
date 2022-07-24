// <copyright file="AddFolder.cshtml.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Pages
{
    using Abstergo.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// Folder creation viewmodel
    /// </summary>
    public class AddFolderModel : PageModel
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddFolderModel"/> class.
        /// </summary>
        /// <param name="context"></param>
        public AddFolderModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// New folder to be created
        /// </summary>
        [BindProperty]
        public Favorite Favorite { get; set; } = default!;

        /// <summary>
        /// Parent folder id
        /// </summary>
        [BindProperty]
        public int FolderID { get; set; } = -1;

        /// <summary>
        /// Last order item
        /// </summary>
        [BindProperty]
        public int LastOrder { get; set; }

        /// <summary>
        /// For display on GET request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task OnGetAsync(int? id, int? order)
        {
            this.FolderID = id ?? -1;
            this.LastOrder = order ?? 0;
            await Task.Yield();
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

            // Create the new one
            this.Favorite.IsFolder = true;
            this.Favorite.ParentID = this.FolderID;
            this.Favorite.Order = this.LastOrder + 1;
            this.context.Links.Add(this.Favorite);
            await this.context.SaveChangesAsync();

            return this.RedirectToPage("/Index", new { id = this.FolderID });
        }
    }
}

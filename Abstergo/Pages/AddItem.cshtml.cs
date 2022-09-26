// <copyright file="AddItem.cshtml.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Pages
{
    using Abstergo.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class AddItemModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public AddItemModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// New favortie to be created
        /// </summary>
        [BindProperty]
        public Favorite Favorite { get; set; } = default!;

        /// <summary>
        /// Parent folder ID
        /// </summary>
        [BindProperty]
        public int FolderID { get; set; } = -1;

        /// <summary>
        /// Last order item
        /// </summary>
        [BindProperty]
        public int LastOrder { get; set; }

        /// <summary>
        /// Last order item
        /// </summary>
        [BindProperty]
        public ItemType ItemType { get; set; }

        public async Task OnGetAsync(int? id, int? order, ItemType? type)
        {
            this.FolderID = id ?? -1;
            this.LastOrder = order ?? 0;
            this.ItemType = type ?? ItemType.Favorite;
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
            this.Favorite.ParentID = this.FolderID;
            this.Favorite.Order = this.LastOrder + 1;
            this.context.Links.Add(this.Favorite);
            await this.context.SaveChangesAsync();

            return this.RedirectToPage("/Index", new { id = this.FolderID });
        }
    }
}

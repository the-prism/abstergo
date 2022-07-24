// <copyright file="Order.cshtml.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Pages
{
    using Abstergo.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Order control view model
    /// </summary>
    public class OrderModel : PageModel
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderModel"/> class.
        /// </summary>
        /// <param name="context"></param>
        public OrderModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// GET request to change the order of elements
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        public async Task OnGetAsync(int? id, int? newOrder)
        {
            Favorite itemToMove = await this.context.Links.FirstOrDefaultAsync((Favorite fav) => fav.Id == id) ?? throw new ArgumentException(nameof(id));
            List<Favorite> listOfFavoritesInFolder = await this.context.Links.Where(f => f.ParentID == itemToMove.ParentID).ToListAsync();
        }
    }
}

﻿// <copyright file="OrderController.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Controllers
{
    using Abstergo.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Controller for ordering actions
    /// </summary>
    public class OrderController : Controller
    {
        /// <summary>
        /// Application database
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="context"></param>
        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Action to change the order of the requested element
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<IActionResult> OrderChangeAsync(int? id, int? newOrder)
        {
            Favorite itemToMove = await this.context.Links.FirstOrDefaultAsync((Favorite fav) => fav.Id == id) ?? throw new ArgumentException(nameof(id));

            // Don't move to order before 0
            if (newOrder < 0)
            {
                return this.RedirectToPage("/Index", new { id = itemToMove.ParentID });
            }

            List<Favorite> listOfFavoritesInFolder = await this.context.Links.Where(f => f.ParentID == itemToMove.ParentID).ToListAsync();

            // Dont move to order larger than count of items in folder
            if (newOrder >= listOfFavoritesInFolder.Count)
            {
                return this.RedirectToPage("/Index", new { id = itemToMove.ParentID });
            }

            Favorite? conflict = listOfFavoritesInFolder.FirstOrDefault(f => f.Order == newOrder);

            // If there is an item with the new order, swap them around
            if (conflict != null)
            {
                conflict.Order = itemToMove.Order;
                this.context.Attach(conflict).State = EntityState.Modified;
            }

            itemToMove.Order = newOrder ?? throw new ArgumentException(nameof(newOrder));
            this.context.Attach(itemToMove).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.FavoriteExists(itemToMove.Id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.RedirectToPage("/Index", new { id = itemToMove.ParentID });
        }

        private bool FavoriteExists(int id)
        {
            return (this.context.Links?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

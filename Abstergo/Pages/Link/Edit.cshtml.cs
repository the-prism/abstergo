﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Abstergo.Data;
using Links = Abstergo.Data.Link;

namespace Abstergo.Pages.Link
{
    public class EditModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext _context;

        public EditModel(Abstergo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Favorite Favorite { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var favorite = await _context.Links.FirstOrDefaultAsync(m => m.Id == id);

            if (favorite is not null)
            {
                favorite.Links = await _context.FavoriteLinks.Where((Links f) => f.FavoriteId == id).ToListAsync();
            }

            if (favorite == null)
            {
                return NotFound();
            }
            Favorite = favorite;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Favorite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(Favorite.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FavoriteExists(int id)
        {
            return (_context.Links?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
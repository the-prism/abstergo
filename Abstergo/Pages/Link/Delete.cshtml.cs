using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abstergo.Data;

namespace Abstergo.Pages.Link
{
    public class DeleteModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext _context;

        public DeleteModel(Abstergo.Data.ApplicationDbContext context)
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

            if (favorite == null)
            {
                return NotFound();
            }
            else 
            {
                Favorite = favorite;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }
            var favorite = await _context.Links.FindAsync(id);

            if (favorite != null)
            {
                Favorite = favorite;
                _context.Links.Remove(Favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

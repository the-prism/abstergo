using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abstergo.Data;
using Links = Abstergo.Data.Link;

namespace Abstergo.Pages.Link
{
    public class DetailsModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext _context;

        public DetailsModel(Abstergo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Favorite Favorite { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Links == null)
            {
                return NotFound();
            }

            var favorite = await _context.Links.Include(p => p.Links).FirstOrDefaultAsync(m => m.Id == id);

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
    }
}

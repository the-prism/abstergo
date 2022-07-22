using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Abstergo.Data;

namespace Abstergo.Pages.Link
{
    public class CreateModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext _context;

        public CreateModel(Abstergo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Favorite Favorite { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Links == null || Favorite == null)
            {
                return Page();
            }

            _context.Links.Add(Favorite);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext _context;

        public IndexModel(Abstergo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Favorite> Favorite { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Links != null)
            {
                Favorite = await _context.Links.ToListAsync();
            }
        }
    }
}

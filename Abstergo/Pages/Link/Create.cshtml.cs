using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Abstergo.Data;
using Microsoft.EntityFrameworkCore;
using Links = Abstergo.Data.Link;
using Microsoft.Extensions.Primitives;

namespace Abstergo.Pages.Link
{
    public class CreateModel : PageModel
    {
        private readonly Abstergo.Data.ApplicationDbContext _context;

        public CreateModel(Abstergo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.Links != null)
            {
                Favorites = await _context.Links.ToListAsync();
            }

            foreach (var entry in Favorites)
            {
                Links.Add(entry.Id);
            }

            return Page();
        }

        [BindProperty]
        public Favorite Favorite { get; set; } = default!;

        public IList<Favorite> Favorites { get; set; } = default!;

        public List<int> Links { get; set; } = new List<int>();


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Links == null || Favorite == null)
            {
                return Page();
            }

            Favorites = await _context.Links.ToListAsync();

            _context.Links.Add(Favorite);
            await _context.SaveChangesAsync();

            var folderContent = Request.Form["Content"];
            var newFav = PrepareFolderContents(Favorite, folderContent);
            _context.Attach(newFav).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private Favorite PrepareFolderContents(Favorite item, StringValues contents)
        {
            int idParent = item.Id;

            foreach (var itemContent in contents)
            {
                item.Links.Add(new Links() { ParentId = idParent, ChildId = int.Parse(itemContent) });
                //var favToAdd = Favorites.FirstOrDefault(f => f.Id == int.Parse(itemContent));
                //if (favToAdd is not null)
                //{
                //    item.Links.Add(favToAdd);
                //}
            }

            return item;
        }
    }
}

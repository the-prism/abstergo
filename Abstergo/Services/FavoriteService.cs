using Abstergo.Data;
using Abstergo.Models;
using Microsoft.EntityFrameworkCore;

namespace Abstergo.Services
{
    public class FavoriteService
    {
        private readonly ILogger<FavoriteService> logger;

        private readonly ApplicationDbContext context;

        public FavoriteService(ILogger<FavoriteService> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public event Action? FolderListChanged;

        public Favorite? CurrentFolder { get; set; } = null;

        public int FolderID { get; set; } = -1;

        public int LastOrder { get; set; }

        public async Task<IList<Favorite>> GetListOfFavoritesAsync(int? id)
        {
            IList<Favorite> favorites = default!;
            if (id == null && this.context.Links != null)
            {
                favorites = await this.context.Links.Where(f => f.ParentID == -1).ToListAsync();
            }
            else if (this.context.Links != null)
            {
                favorites = await this.context.Links.Where(f => f.ParentID == id).ToListAsync();
                this.CurrentFolder = await this.context.Links.FirstOrDefaultAsync(f => f.Id == id);
                this.FolderID = id ?? -1;
            }

            favorites = favorites.OrderBy(f => f.Order).ToList();
            if (favorites.Any())
            {
                this.LastOrder = favorites.Last().Order;
            }
            else
            {
                this.LastOrder = -1;
            }

            return favorites;
        }

        public async Task OrderChangeAsync(int? id, int? newOrder)
        {
            Favorite itemToMove = await this.context.Links.FirstOrDefaultAsync((Favorite fav) => fav.Id == id) ?? throw new ArgumentException(nameof(id));

            // Don't move to order before 0
            if (newOrder < 0)
            {
                return;
            }

            List<Favorite> listOfFavoritesInFolder = await this.context.Links.Where(f => f.ParentID == itemToMove.ParentID).ToListAsync();

            // Dont move to order larger than count of items in folder
            if (newOrder >= listOfFavoritesInFolder.Count)
            {
                return;
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

                this.FolderListChanged?.Invoke();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.FavoriteExists(itemToMove.Id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task AddNewItem(Favorite item)
        {
            item.ParentID = this.FolderID;
            item.Order = this.LastOrder + 1;
            this.context.Links.Add(item);
            await this.context.SaveChangesAsync();

            this.FolderListChanged?.Invoke();
        }

        public async Task DeleteItem(Favorite item)
        {
            this.context.Links.Remove(item);
            await this.context.SaveChangesAsync();

            this.FolderListChanged?.Invoke();
        }

        public async Task UpdateItem(Favorite item)
        {
            this.context.Attach(item).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();

                this.FolderListChanged?.Invoke();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.FavoriteExists(item.Id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool FavoriteExists(int id)
        {
            return (this.context.Links?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

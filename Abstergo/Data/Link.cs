namespace Abstergo.Data
{
    public class Link
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int ChildId { get; set; }

        public int FavoriteId { get; set; }
        public Favorite Favorite { get; set; }
    }
}

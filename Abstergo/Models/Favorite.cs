using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Abstergo.Models
{
    public class Favorite
    {
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; } = string.Empty;

        [DataMember]
        public string Url { get; set; } = string.Empty;

        [DataMember]
        public ItemType ItemType { get; set; } = ItemType.Favorite;

        [DataMember]
        public int ParentID { get; set; } = -1;

        public bool IsPinned { get; set; } = false;

        public int Order { get; set; }

        public ItemIcon Icon { get; set; }

        public ItemColor Color { get; set; }
    }
}

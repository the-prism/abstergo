using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Abstergo.Data
{
    public class Favorite
    {
        [DataMember] 
        public int Id { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataMember]
        public string Url { get; set; } = string.Empty;

        [DataMember]
        public bool IsFolder { get; set; }

        [DataMember(IsRequired = false)]
        public int? ParentId { get; set; } = null;

        public List<Favorite> FolderContents { get; set; } = new List<Favorite>();
    }
}

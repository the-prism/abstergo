// <copyright file="Favorite.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

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

        public List<Link> Links { get; set; } = new List<Link>();
    }
}

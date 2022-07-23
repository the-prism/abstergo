// <copyright file="Favorite.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// Data model for a favorite
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// Database item id
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Name of the favorite
        /// </summary>
        [Required]
        [DataMember]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Link url
        /// </summary>
        [DataMember]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Boolean to indicate if it a link or a folder
        /// </summary>
        [DataMember]
        public bool IsFolder { get; set; }

        /// <summary>
        /// List of links for a folder
        /// </summary>
        public List<Link> Links { get; set; } = new List<Link>();
    }
}

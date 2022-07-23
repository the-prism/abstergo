// <copyright file="Link.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Data
{
    /// <summary>
    /// Data model for links
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Database id of a link
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Parent ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Child ID
        /// </summary>
        public int ChildId { get; set; }

        /// <summary>
        /// Favorite id of the link associated
        /// </summary>
        public int FavoriteId { get; set; }

        /// <summary>
        /// Reference to the parent
        /// </summary>
        public Favorite? Favorite { get; set; }
    }
}

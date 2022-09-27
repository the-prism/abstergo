// <copyright file="ItemIcon.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Blazor.Data
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:Enumeration items should be documented")]
    public enum ItemIcon
    {
        [EnumCharSet('\xF507')]
        [EnumValue("bi-question-diamond")]
        Unknown,

        [EnumCharSet('\xF3D7')]
        [EnumValue("bi-folder")]
        Folder,

        [EnumCharSet('\xF470')]
        [EnumValue("bi-link-45deg")]
        Link,
    }
}

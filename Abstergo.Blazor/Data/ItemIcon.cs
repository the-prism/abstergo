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

        [EnumCharSet('\xF52E')]
        [EnumValue("bi-share")]
        Share,

        [EnumCharSet('\xF10D')]
        [EnumValue("bi-archive")]
        Archive,

        [EnumCharSet('\xF10A')]
        [EnumValue("bi-app-indicator")]
        Indicator,

        [EnumCharSet('\xF154')]
        [EnumValue("bi-award")]
        Award,

        [EnumCharSet('\xF150')]
        [EnumValue("bi-aspect-ratio")]
        Ratio,

        [EnumCharSet('\xF155')]
        [EnumValue("bi-back")]
        Overlay,

        [EnumCharSet('\xF179')]
        [EnumValue("bi-bag")]
        Bag,

        [EnumCharSet('\xF62E')]
        [EnumValue("bi-bank")]
        Bank,

        [EnumCharSet('\xF17E')]
        [EnumValue("bi-bar-chart")]
        Bar,

        [EnumCharSet('\xF19D')]
        [EnumValue("bi-bookmark-plus")]
        BookmarkPlus,

        [EnumCharSet('\xF4CA')]
        [EnumValue("bi-pencil-square")]
        Edit,
    }
}

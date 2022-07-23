// <copyright file="Index.cshtml.cs" company="the-prism">
// Copyright (c) the-prism. All rights reserved.
// </copyright>

namespace Abstergo.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            this.logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
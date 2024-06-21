using Bloggie.Data;
using Bloggie.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Pages.Admin.Blogs
{
    
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        public ListModel(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        public List<BlogPost> BlogPosts { get; set; }
        public async Task OnGet()
        {
			BlogPosts =await bloggieDbContext.BlogPosts.ToListAsync();
           //var a= BlogPosts[0].Id; // In case you want to access here only 
           //var b = BlogPosts[0].Heading;
        }
        
    }
}

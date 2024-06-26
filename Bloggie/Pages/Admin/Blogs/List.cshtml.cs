using Bloggie.Data;
using Bloggie.Models.Domain;
using Bloggie.Models.ViewModels;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Bloggie.Pages.Admin.Blogs
{
    
    public class ListModel : PageModel
    {
        //private readonly BloggieDbContext bloggieDbContext;

        //public ListModel(BloggieDbContext bloggieDbContext)
        //{
        //    this.bloggieDbContext = bloggieDbContext;
        //}

        private readonly IBlogPostRepository blogPostRepository;
        public ListModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public List<BlogPost> BlogPosts { get; set; }
        public async Task OnGet()
        {
            //BlogPosts =await bloggieDbContext.BlogPosts.ToListAsync();
            //var a= BlogPosts[0].Id; // In case you want to access here only 
            //var b = BlogPosts[0].Heading;

            //

            // var messageDescription = (string) TempData["MessageDescription"];
            var notificationJson = (String) TempData["Notification"];
            //if (!string.IsNullOrEmpty(messageDescription)) 
            //{
            //    ViewData["MessageDescription"]= messageDescription;
            //}
            if (notificationJson != null) 
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson.ToString());


            }

            BlogPosts = (await blogPostRepository.GetAllAsync())?.ToList();// you can also use BlogPosts =(List<BlogPost>) await  blogPostRepository.GetAllAsync();
                                                                            //to explicitly cast IEnumerable to List
        }

    }
}

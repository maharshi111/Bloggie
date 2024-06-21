using Bloggie.Data;
using Bloggie.Models.Domain;
using Bloggie.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly BloggieDbContext bloggieDbContext;

        public AddModel(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }// injecting DbContext , so that we can access the database

        //[BindProperty]
        //public string Heading { get; set; }
        //[BindProperty]
        //public string Title { get; set; }

        //Instead of doing the above for  each and every property , what we did is we creted a class named AddBlogPost in which we have defined each and every property

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }



        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() 
        {
            // var heading = Request.Form["heading"];//by this manner we can  directly access the the form data that was submitted via an HTTP POST request, but we will not
            //use this direct access method as it manual and has many drawbacks,So we did the above method(comment ), see the e-notes I have mentioned there in details 

            BlogPost blogPost = new BlogPost
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible,
            };


            await bloggieDbContext.BlogPosts.AddAsync(blogPost);
            await bloggieDbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}

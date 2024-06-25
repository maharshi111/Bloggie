using Bloggie.Data;
using Bloggie.Models.Domain;
using Bloggie.Models.ViewModels;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {


        // private readonly BloggieDbContext bloggieDbContext;

        //public AddModel(BloggieDbContext bloggieDbContext)
        //{
        //    this.bloggieDbContext = bloggieDbContext;
        //}// injecting DbContext , so that we can access the database

        //As we have injected the IBlogPostRepository service  in the program.cs file we now no longer need to inject dbcontext here so commenting the above  part and injecting the 
        //IBlogPostRepository below

        private readonly IBlogPostRepository blogPostRepository;
        public AddModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

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


            //await bloggieDbContext.BlogPosts.AddAsync(blogPost);
            //await bloggieDbContext.SaveChangesAsync();

            // commenting the above part as we no longer need DbContext , below is the replacement of the above part as we have injected the IBlogPostRepository 

           await blogPostRepository.AddAsync(blogPost);
            TempData["MessageDescription"] = "New Blog Post Created !";

            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}

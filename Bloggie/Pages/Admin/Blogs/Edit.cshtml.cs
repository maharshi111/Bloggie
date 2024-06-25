using Bloggie.Data;
using Bloggie.Models.Domain;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {


        //private readonly BloggieDbContext _db;

        //public EditModel(BloggieDbContext db)
        //{
        //    _db = db;
        //}

        private readonly IBlogPostRepository blogPostRepository;
        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public async Task OnGet(Guid id)  // this was intially public void OnGet , see when convert to async then if the method is IAction than write that
                                          // method inside Task , the general notation is async Task<return type method (say IActionResult)>, if the return type 
                                          //of method is void than write like this  public async Task OnGet
        {
           // BlogPost = await _db.BlogPosts.FindAsync(id);
            BlogPost = await blogPostRepository.GetAsync(id);
        }

        public async Task< IActionResult> OnPostEdit() 
        {
            //var existingBlogPost = await _db.BlogPosts.FindAsync(BlogPost.Id);
            //if (existingBlogPost != null)
            //{
            //    existingBlogPost.Heading = BlogPost.Heading;
            //    existingBlogPost.PageTitle = BlogPost.PageTitle;
            //    existingBlogPost.Content = BlogPost.Content;
            //    existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
            //    existingBlogPost.Author = BlogPost.Author;
            //    existingBlogPost.PublishedDate = BlogPost.PublishedDate;
            //    existingBlogPost.Visible = BlogPost.Visible;
            //    existingBlogPost.ShortDescription = BlogPost.ShortDescription;
            //    existingBlogPost.UrlHandle = BlogPost.UrlHandle;

            //}

            //    //you can also use update to do the same above functionality, but you if use this than it will break when id is invalid , in this case BlogPost will be null and thus it will throw error while updating
            //    //_db.BlogPosts.Update(BlogPost); 

            //  await  _db.SaveChangesAsync();

            await   blogPostRepository.UpdateAsync(BlogPost);

            ViewData["Message Description"] = "Record was successfully saved";
            return Page();

           // return RedirectToPage("/Admin/Blogs/List");
        }

        public async Task<IActionResult> OnPostDelete() 
        {
            //var existingBlogPost = await _db.BlogPosts.FindAsync(BlogPost.Id);
            //if (existingBlogPost != null) 
            //{
            //     _db.BlogPosts.Remove(existingBlogPost);
            //   await _db.SaveChangesAsync();
            //    return RedirectToPage("/Admin/Blogs/List");
            //}

            var result = await blogPostRepository.DeleteAsync(BlogPost.Id);
            if (result == true)
            {
                return RedirectToPage("/Admin/Blogs/List");
            }

           


            return Page();
        }
    }
}

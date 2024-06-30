using Bloggie.Models.Domain;
using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostRepository blogPostRepository;
         public List<BlogPost> Blogs { get; set; }

        public IndexModel(ILogger<IndexModel> logger,IBlogPostRepository blogPostRepository)
        {
            _logger = logger;
            this.blogPostRepository = blogPostRepository;
        }

        //public async Task OnGet()
        //{
        //    var blogs  = await blogPostRepository.GetAllAsync();
        //    Blogs = blogs.ToList();
        //}
        public async Task<IActionResult> OnGet()
        {
            var blogs = (await blogPostRepository.GetAllAsync());
            Blogs = blogs.ToList();
            return Page();
        }
        //you can write the method OnGet in both ways see Q2 IN OtherKeyConcepts e notes also see Q1 in that to known why we can't  assign the var blogs outside OnGET
    }
}

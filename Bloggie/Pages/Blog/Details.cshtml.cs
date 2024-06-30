using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bloggie.Repositories;
using Bloggie.Models.Domain;


namespace Bloggie.Pages.Blog
{
    public class DetailsModel : PageModel
    {
		private readonly IBlogPostRepository blogRepository;

        public BlogPost BlogPost { get; set; }
		public DetailsModel(IBlogPostRepository blogRepository)
        {
			this.blogRepository = blogRepository;
		}
        public async Task OnGet(string urlHandle)
        {
          BlogPost= await blogRepository.GetAsync(urlHandle);
        }
    }
}

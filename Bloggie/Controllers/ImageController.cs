using Bloggie.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bloggie.Controllers
{
    [ApiController]
    //[Route("api/image")]
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly IImageRepository imageRepository;
        public ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var imageUrl = await imageRepository.UploadAsync(file);
            if (imageUrl == null) 
            {
                return Problem("something went wrong!", null, (int?)HttpStatusCode.InternalServerError);
            }
            return Json(new { link = imageUrl });
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace DreemDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = ("Admin,Customer,ServiceProvider"))]

    public class FilesController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public async Task<string> UploadImagesAndGetURL(IFormFile file)
        {
          string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
          if (file == null || file.Length == 0)
          {
            throw new Exception("Please Enter Valid File");
          }
       
          string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
          string filePath = Path.Combine(uploadFolder, newFileName);
       
          using (var inputFile = new FileStream(filePath, FileMode.Create))
          {
            await file.CopyToAsync(inputFile);
          }
       
          // Construct the full URL to return

            return newFileName;
        }
        [HttpGet("{fileName}")]
        public IActionResult GetFile( string fileName) 
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File Name is Not Provided");
            }
            var filePath = Path.Combine(uploadFolder, fileName);
            if (!System.IO.File.Exists(filePath)) 
            {
                return NotFound("File Not Found");
            }
            var contnetType = GetContentType(filePath);
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, contnetType, fileName);


        }
        private static string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace DreemDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public async Task<String> UploadImagesAndGetURL(IFormFile file)
        {
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (file == null || file.Length == 0) 
            {
                throw new Exception("Please Enter Valid File");
            }
            string newFileURL = Guid.NewGuid().ToString() + "" + file.FileName;
            using (var inputFile = new FileStream(Path.Combine(uploadFolder, newFileURL), FileMode.Create))
            {
                await file.CopyToAsync(inputFile);
            }
            return newFileURL;

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

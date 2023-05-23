using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UpLoad(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //folder
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media/Upload");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            //Path
            var path = Path.Combine(folder, file.FileName);
                    
            //Stream

            using(var stream=new FileStream(path,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            //Response Body
            return Ok(new
            {
                file = file.FileName,
                path = path,
                size=file.Length
            });
        }
        [HttpGet("download")]
        public async Task<IActionResult> Download(string fileName)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // FilePath
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media/Upload", fileName);

            // ContentType : (MIME)
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            // Read
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));

        }

    }
}

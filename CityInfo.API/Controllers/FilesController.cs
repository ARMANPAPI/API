using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [Route("api/Files")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        //Injection For API => Download File 
        FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        public FilesController(
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }
        //////////////

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            string pasthToFile = "download.rar";
            if(!System.IO.File.Exists(pasthToFile)) { return NotFound(); }

            var bytes=System.IO.File.ReadAllBytes(pasthToFile);
            if(!_fileExtensionContentTypeProvider.TryGetContentType(pasthToFile,
                out var contentType))
            {
                contentType = "application/otet-stream";    
            }
            return File(bytes,contentType,Path.GetFileName(pasthToFile));
        }

    }
}

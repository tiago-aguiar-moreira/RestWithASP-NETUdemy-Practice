using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SendFiles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private static string path = Directory.GetCurrentDirectory() + @"\FilesDownload\Example.pdf";

        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("v1")]
        public async Task<FileContentResult> GetV1()
        {
            var buffer = await System.IO.File.ReadAllBytesAsync(path);
            
            return new FileContentResult(buffer, "application/pdf")
            {
                FileDownloadName = Path.GetFileName(path)
            };
        }

        [HttpGet]
        [Route("v2")]
        public async Task<FileContentResult> GetV2()
        {
            byte[] buffer;
            
            using (FileStream SourceStream = System.IO.File.Open(path, FileMode.Open))
            {
                buffer = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(buffer, 0, (int)SourceStream.Length);
            }

            return new FileContentResult(buffer, "application/pdf")
            {
                FileDownloadName = Path.GetFileName(path)
            };
        }

        [HttpGet]
        [Route("v3")]
        public async Task<IActionResult> GetV3()
        {
            var buffer = System.IO.File.ReadAllBytes(path);
            
            if(buffer != null)
            {
                HttpContext.Response.ContentType = "application/pdf";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                await HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
            }

            return new ContentResult();
        }
    }
}

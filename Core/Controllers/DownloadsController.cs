using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace montiepy2.Core.Controllers{
    [Route("[controller]/[action]")]
    public class DownloadsController : Controller
    {
        [HttpGet]
        public FileContentResult CV()
        {
            byte[] filebytes = System.IO.File.ReadAllBytes("cv.pdf");
            FileContentResult result = new FileContentResult(filebytes, "application/octet-stream") {
                FileDownloadName = "vlad-bodrug_resume.pdf"
            };
            return result;
        }
    }
}
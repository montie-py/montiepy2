using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using montiepy2.Core.Services;

namespace montiepy2.Core.Controllers{
    [Route("[controller]/[action]")]
    public class DownloadsController : Controller
    {
        private ResumeService _resumeService;

        public DownloadsController(ResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        [HttpGet]
        public FileContentResult CV()
        {
            var resumeFileName = _resumeService.GetResumeName();
            byte[] filebytes = System.IO.File.ReadAllBytes(resumeFileName);
            FileContentResult result = new FileContentResult(filebytes, "application/octet-stream") {
                FileDownloadName = "vlad-bodrug_resume.pdf"
            };
            return result;
        }
    }
}
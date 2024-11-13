using montiepy2.Core.Enums;

namespace montiepy2.Core.Services
{
    public class ResumeService : IResumeService
    {
        private const string DefaultResumeFile = "cv.pdf";
        private IHttpContextAccessor _httpContextAccessor;

        private Dictionary<ResumeType, string> ResumeFileNames = new()
        {
            [ResumeType.Csharp] = "c_cv.pdf",
            [ResumeType.Java] = "j_cv.pdf",
            [ResumeType.Php] = "p_cv.pdf",
            [ResumeType.Cj] = "cj_cv.pdf",
            [ResumeType.Cp] = "cp_cv.pdf",
            [ResumeType.Jp] = "jp_cv.pdf",
        };

        public ResumeService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetResumeName()
        {
            var resumeTypeSession = _httpContextAccessor.HttpContext.Session.GetString("res");

            if (resumeTypeSession == null || !Enum.TryParse(resumeTypeSession, out ResumeType resumeType) || !ResumeFileNames.ContainsKey(resumeType)) {
                return DefaultResumeFile;
            }

            return ResumeFileNames[resumeType];
        }
    }
}
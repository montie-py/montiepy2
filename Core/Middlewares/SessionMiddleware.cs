using Microsoft.Extensions.Primitives;
using montiepy2.Core.Enums;

namespace montiepy2.Core.Middlewares
{
    internal class SessionMiddleware
    {
        RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var queryParams = context.Request.Query;

            if (queryParams.ContainsKey("welcome")) {
                var welcomeType = queryParams["welcome"];
                if (StringValues.IsNullOrEmpty(welcomeType) || welcomeType.ToString().Length > 2) {
                    //redirect to the main page
                    context.Response.Redirect("/");
                    return;
                }

                string welcomeString = welcomeType.ToString().ToLower();
                if (welcomeString.Length >= 2) {
                    welcomeString = string.Concat(welcomeString.OrderBy(ch => ch));
                }
                ResumeType? resumeType = ResumeTypeByString(welcomeString);
                if (resumeType == null) {
                    //redirect to the main page
                    context.Response.Redirect("/");
                    return;
                }

                context.Session.SetString("res", resumeType.ToString());
                //redirect to the main page
                context.Response.Redirect("/");
                return;
            }
            await _next(context);
        }

        private ResumeType? ResumeTypeByString(string welcomeString)
        {
            return welcomeString switch
            {
                "j" => ResumeType.Java,
                "c" => ResumeType.Csharp,
                "p" => ResumeType.Php,
                "cj" => ResumeType.Cj,
                "cp" => ResumeType.Cp,
                "jp" => ResumeType.Jp,
                _ => null
            };
        }
    }
}
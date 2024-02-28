using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webitor.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseHttpStatusEmailMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HttpStatusEmailMiddleware>();
        }
    }
}

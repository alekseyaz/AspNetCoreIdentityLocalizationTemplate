using AspNetCoreIdentityLocalization.Resources;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace AspNetCoreIdentityLocalization
{
    public class PageModelLocalizer : PageModel
    {

        public IStringLocalizer SharedLocalizer { get; }

        public PageModelLocalizer(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            SharedLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }
    }
}

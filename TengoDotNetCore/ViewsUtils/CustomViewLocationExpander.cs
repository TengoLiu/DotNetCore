using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

namespace TengoDotNetCore.ViewsUtils {
    public class CustomViewLocationExpander : IViewLocationExpander {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations) {
            string name = context.Values["Theme"];
            if (name != "Views") {
                viewLocations = viewLocations.Select(s => s.Replace("Views", name));
            }
            return viewLocations;

        }

        public void PopulateValues(ViewLocationExpanderContext context) {
            if (context.ActionContext.HttpContext.Request.IsMobileBrowser()) {
                context.Values["Theme"] = "ViewsMobile";
            }
            else {
                context.Values["Theme"] = "Views";
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Nest.ViewModels;

namespace Nest.Helpers.HTML {
    public static class PaginationHelper {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PaginationViewModel pagingInfo, Func<int, string> pageUrl) {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++) {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == 1) {
                    tag.AddCssClass("ml-auto");
                }
                if (i == pagingInfo.CurrentPage) {
                    tag.AddCssClass("btn-warning text-dark");
                }
                tag.AddCssClass("btn text-light");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}

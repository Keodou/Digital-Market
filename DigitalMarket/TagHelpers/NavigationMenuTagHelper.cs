using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DigitalMarket.TagHelpers
{
    public class NavigationMenuTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public NavigationMenuTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> UrlValues { get; set; } = new Dictionary<string, object>();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            var result = new TagBuilder("div");
            var tag = new TagBuilder("a");
            tag.Attributes["href"] = urlHelper.Action(PageAction, UrlValues);
            result.InnerHtml.AppendHtml(tag);
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}

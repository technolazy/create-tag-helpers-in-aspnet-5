using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomTagHelpers.TagHelpers
{
    public class BoldTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var classValue = context.AllAttributes["class"].Value;
            var existingContent = await context.GetChildContentAsync();
            existingContent.Append(" It is!");

            output.TagName = "span";
            output.Attributes.Clear();
            output.Content.SetContent(existingContent);
            output.PreContent.AppendEncoded($"<strong class='{classValue}'>");
            output.PostContent.AppendEncoded("</strong>");

        }
    }
}

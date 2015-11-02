using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomTagHelpers.TagHelpers
{
    public class MyFirstTagHelper : TagHelper
    {
        //my-first

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.Append("This is some content");
        }
    }
}

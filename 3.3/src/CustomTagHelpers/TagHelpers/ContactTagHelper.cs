using CustomTagHelpers.Data;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomTagHelpers.TagHelpers
{
    [HtmlTargetElement("contact", Attributes = EmailAttributeName)]
    public class ContactTagHelper : TagHelper
    {
        private const string EmailAttributeName = "foo-email";

        [HtmlAttributeName(EmailAttributeName)]
        public string Email { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var contacts = new ContactRepository();
            var contact = await contacts.GetAsync(Email);

            if (contact == null)
            {
                output.TagName = null;
                return;
            }

            output.TagName = "div";
            output.PreContent.SetContentEncoded("<form>");

            var hidden = CreateInputElement("hidden", contact.Id.ToString());
            var textBox = CreateInputElement("text", "");
            var submit = CreateInputElement("submit", "Send Message");

            output.Content.Append(hidden);
            output.Content.Append(textBox);
            output.Content.Append(submit);

            output.PostContent.SetContentEncoded("</form>");


        }

        private TagBuilder CreateInputElement(string type, string value)
        {
            var input = new TagBuilder("input");
            input.Attributes.Add("type", type);
            input.Attributes.Add("value", value);

            return input;
        }

    }
}

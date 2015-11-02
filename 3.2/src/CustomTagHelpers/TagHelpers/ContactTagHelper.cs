using CustomTagHelpers.Data;
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

            output.TagName = "form";
            output.Content.AppendEncoded($"<input type='hidden' value='{contact.Id}' />");
            output.Content.AppendEncoded($"<input type='text' value='' />");
            output.Content.AppendEncoded($"<input type='submit' value='Send Message' />");

        }

    }
}

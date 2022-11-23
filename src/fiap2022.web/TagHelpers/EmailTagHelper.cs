using Microsoft.AspNetCore.Razor.TagHelpers;

namespace fiap2022.TagHelpers
{
    public class EmailTagHelper :TagHelper
    {
        private const string EmailDomain = "fiap.com.br";
        public string MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            var address = $"{MailTo}@{EmailDomain}";

            output.Attributes.SetAttribute("href",$"mailto:{address}");
            output.Content.SetContent(address);

        }

    }
}

using System.Collections.Generic;

namespace Discord
{
    public class CDNEndpoint
    {
        public string Template { get; private set; }
        public IReadOnlyList<DiscordImageFormat> AllowedFormats { get; private set; }

        public CDNEndpoint(string template, List<DiscordImageFormat> allowedFormats)
        {
            Template = template;
            AllowedFormats = allowedFormats;
        }
    }
}

using System.Collections.Generic;

namespace Discord
{
    public class MediaEndpoint
    {
        public string Host { get; private set; } = "media.discordapp.net";
        public string Template { get; private set; }
        public IReadOnlyList<DiscordImageFormat> AllowedFormats { get; private set; }

        public MediaEndpoint(string template, List<DiscordImageFormat> allowedFormats) : this("media.discordapp.net", template, allowedFormats) { }
        public MediaEndpoint(string host, string template, List<DiscordImageFormat> allowedFormats)
        {
            Host = host;
            Template = template;
            AllowedFormats = allowedFormats;
        }
    }
}
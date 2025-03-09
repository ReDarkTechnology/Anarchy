using System.Collections.Generic;

namespace Discord
{
    internal static class MediaEndpoints
    {
        public static List<DiscordImageFormat> CommonFormats = new List<DiscordImageFormat>()
        {
            DiscordImageFormat.PNG,
            DiscordImageFormat.JPG,
            DiscordImageFormat.WebP
        };

        public static List<DiscordImageFormat> AllFormats = new List<DiscordImageFormat>()
        {
            DiscordImageFormat.PNG,
            DiscordImageFormat.JPG,
            DiscordImageFormat.WebP,
            DiscordImageFormat.GIF
        };

        // Why so specific...
        public static readonly MediaEndpoint GuildSticker = new MediaEndpoint("stickers/{0}", AllFormats);
        public static readonly MediaEndpoint StandardSticker = new MediaEndpoint("https://canary.discord.com", "stickers/{0}", AllFormats);
    }
}

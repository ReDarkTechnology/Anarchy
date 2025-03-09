using System.Collections.Generic;

namespace Discord
{
    internal static class CDNEndpoints
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

        // Applications
        public static readonly CDNEndpoint TeamIcon = new CDNEndpoint("team-icons/{0}/{1}", CommonFormats);
        public static readonly CDNEndpoint AppIcon = new CDNEndpoint("app-icons/{0}/{1}", CommonFormats);
        public static readonly CDNEndpoint AchievementIcon = new CDNEndpoint("app-assets/{0}/achievements/{1}/icons/{2}", CommonFormats);

        // Guild
        public static readonly CDNEndpoint GuildIcon = new CDNEndpoint("icons/{0}/{1}", AllFormats);
        public static readonly CDNEndpoint Banner = new CDNEndpoint("banners/{0}/{1}", CommonFormats);
        public static readonly CDNEndpoint Splash = new CDNEndpoint("splashes/{0}/{1}", CommonFormats);
        public static readonly CDNEndpoint DiscoverySplash = new CDNEndpoint("discovery-splashes/{0}/{1}", CommonFormats);
        public static readonly CDNEndpoint Emoji = new CDNEndpoint("emojis/{0}", new List<DiscordImageFormat>()
        {
            DiscordImageFormat.PNG,
            DiscordImageFormat.GIF
        });

        // Private
        public static readonly CDNEndpoint ChannelIcon = new CDNEndpoint("channel-icons/{0}/{1}", CommonFormats);
        public static readonly CDNEndpoint Avatar = new CDNEndpoint("avatars/{0}/{1}", AllFormats);
        public static readonly CDNEndpoint DefaultAvatar = new CDNEndpoint("embed/avatars/{0}", new List<DiscordImageFormat>() { DiscordImageFormat.PNG });
    }
}

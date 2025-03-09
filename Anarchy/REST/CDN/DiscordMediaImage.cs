using System;
using System.Collections.Generic;
using System.Linq;

namespace Discord
{
    public class DiscordMediaImage
    {
        public string Url { get; private set; }
        public object[] Particles { get; private set; }
        public IReadOnlyList<DiscordImageFormat> AllowedFormats { get; private set; }

        public DiscordMediaImage(MediaEndpoint endpoint, params object[] assets)
        {
            Url = $"https://{endpoint.Host}/{string.Format(endpoint.Template, assets)})";
            Particles = assets;

            AllowedFormats = endpoint.AllowedFormats.Distinct().ToList();
        }

        public DiscordImage Download(DiscordImageFormat format = DiscordImageFormat.Any)
        {
            if (format != DiscordImageFormat.Any && !AllowedFormats.Contains(format))
                throw new NotSupportedException("Image format not supported. The supported formats for this endpoint are: " + string.Join(", ", AllowedFormats));

            string url = Url;

            if (format != DiscordImageFormat.Any)
                url += "." + format.ToString().ToLower();

            return DiscordImageSource.FromUrl(url).Result;
        }

        public DiscordImage Download(DiscordImageFormat format, int size)
        {
            if (format != DiscordImageFormat.Any && !AllowedFormats.Contains(format))
                throw new NotSupportedException("Image format not supported. The supported formats for this endpoint are: " + string.Join(", ", AllowedFormats));

            string url = Url;

            if (format != DiscordImageFormat.Any)
                url += "." + format.ToString().ToLower();

            if (size > 32)
                url += "?size=" + size;

            return DiscordImageSource.FromUrl(url).Result;
        }

        public string GetUrl(DiscordImageFormat format = DiscordImageFormat.Any)
        {
            if (format != DiscordImageFormat.Any && !AllowedFormats.Contains(format))
                throw new NotSupportedException("Image format not supported. The supported formats for this endpoint are: " + string.Join(", ", AllowedFormats));

            string url = Url;

            if (format != DiscordImageFormat.Any)
                url += "." + format.ToString().ToLower();
            return url;
        }

        public string GetUrl(DiscordImageFormat format, int size)
        {
            if (format != DiscordImageFormat.Any && !AllowedFormats.Contains(format))
                throw new NotSupportedException("Image format not supported. The supported formats for this endpoint are: " + string.Join(", ", AllowedFormats));

            string url = Url;

            if (format != DiscordImageFormat.Any)
                url += "." + format.ToString().ToLower();

            if (size > 32)
                url += "?size=" + size;

            return url;
        }
    }
}

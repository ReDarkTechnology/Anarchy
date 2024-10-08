﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Discord
{
    public class DiscordCDNImage
    {
        public string Url { get; private set; }
        public object[] Particles { get; private set; }
        public IReadOnlyList<DiscordCDNImageFormat> AllowedFormats { get; private set; }

        public DiscordCDNImage(CDNEndpoint endpoint, params object[] assets)
        {
            Url = "https://cdn.discordapp.com/" + string.Format(endpoint.Template, assets);
            Particles = assets;

            AllowedFormats = endpoint.AllowedFormats.Distinct().ToList();
        }

        public DiscordImage Download(DiscordCDNImageFormat format = DiscordCDNImageFormat.Any)
        {
            if (format != DiscordCDNImageFormat.Any && !AllowedFormats.Contains(format))
                throw new NotSupportedException("Image format not supported. The supported formats for this endpoint are: " + string.Join(", ", AllowedFormats));

            string url = Url;

            if (format != DiscordCDNImageFormat.Any)
                url += "." + format.ToString().ToLower();

            return DiscordImageSource.FromUrl(url).Result;
        }

        public DiscordImage Download(DiscordCDNImageFormat format, int size)
        {
            if (format != DiscordCDNImageFormat.Any && !AllowedFormats.Contains(format))
                throw new NotSupportedException("Image format not supported. The supported formats for this endpoint are: " + string.Join(", ", AllowedFormats));

            string url = Url;

            if (format != DiscordCDNImageFormat.Any)
                url += "." + format.ToString().ToLower();

            if (size > 32)
                url += "?size=" + size;

            return DiscordImageSource.FromUrl(url).Result;
        }

        public string GetUrl(DiscordCDNImageFormat format = DiscordCDNImageFormat.Any)
        {
            if (format != DiscordCDNImageFormat.Any && !AllowedFormats.Contains(format))
                throw new NotSupportedException("Image format not supported. The supported formats for this endpoint are: " + string.Join(", ", AllowedFormats));

            string url = Url;

            if (format != DiscordCDNImageFormat.Any)
                url += "." + format.ToString().ToLower();
            return url;
        }

        public string GetUrl(DiscordCDNImageFormat format, int size)
        {
            if (format != DiscordCDNImageFormat.Any && !AllowedFormats.Contains(format))
                throw new NotSupportedException("Image format not supported. The supported formats for this endpoint are: " + string.Join(", ", AllowedFormats));

            string url = Url;

            if (format != DiscordCDNImageFormat.Any)
                url += "." + format.ToString().ToLower();

            if (size > 32)
                url += "?size=" + size;

            return url;
        }
    }
}

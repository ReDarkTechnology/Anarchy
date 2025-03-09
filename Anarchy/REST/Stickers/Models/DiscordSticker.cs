using Newtonsoft.Json;

namespace Discord
{
    public class DiscordSticker : Controllable
    {
        [JsonProperty("id")]
        public ulong Id { get; private set; }

        [JsonProperty("pack_id")]
        public ulong? PackId { get; private set; }

        [JsonProperty("guild_id")]
        public ulong? GuildId { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("asset")]
        public string AssetHash { get; private set; }

        [JsonProperty("type")]
        public StickerType Type { get; private set; }

        [JsonProperty("format_type")]
        public StickerFormatType FormatType { get; private set; }

        [JsonProperty("tags")]
        public string Tags { get; private set; }

        [JsonProperty("available")]
        public bool Available { get; private set; }


        public string Url
        {
            get
            {
                if (Type == StickerType.GUILD)
                    return $"https://{MediaEndpoints.GuildSticker.Host}/{string.Format(MediaEndpoints.GuildSticker.Template, Id)}";
                else
                    return $"https://{MediaEndpoints.StandardSticker.Host}/{string.Format(MediaEndpoints.StandardSticker.Template, Id)}";
            }
        }

        public DiscordMediaImage Image
        {
            get
            {
                return new DiscordMediaImage(Type == StickerType.GUILD ? MediaEndpoints.GuildSticker : MediaEndpoints.StandardSticker, Id);
            }
        }
    }
}

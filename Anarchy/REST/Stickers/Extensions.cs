using System.Collections.Generic;
using System.Threading.Tasks;

namespace Discord
{
    public static class StickerExtensions
    {
        #region Listing
        public static async Task<IReadOnlyList<DiscordSticker>> GetGuildStickersAsync(this DiscordClient client, ulong guildId)
        {
            var stickers = (await client.HttpClient.GetAsync($"/guilds/{guildId}/stickers"))
                                        .Deserialize<IReadOnlyList<DiscordSticker>>().SetClientsInList(client);
            foreach (var sticker in stickers)
                sticker.GuildId = guildId;
            return stickers;
        }

        /// <summary>
        /// Gets the guild's stickers
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        public static IReadOnlyList<DiscordSticker> GetGuildStickers(this DiscordClient client, ulong guildId) =>
            client.GetGuildStickersAsync(guildId).ToSync();

        public static async Task<DiscordSticker> GetStickerAsync(this DiscordClient client, ulong stickerId)
        {
            DiscordSticker reaction = (await client.HttpClient.GetAsync($"/stickers/{stickerId}"))
                                        .Deserialize<DiscordSticker>().SetClient(client);
            return reaction;
        }

        /// <summary>
        /// Gets an sticker
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <param name="stickerId">ID of the sticker</param>
        public static DiscordSticker GetGuildSticker(this DiscordClient client, ulong stickerId) =>
            client.GetStickerAsync(stickerId).ToSync();
        #endregion
    }
}

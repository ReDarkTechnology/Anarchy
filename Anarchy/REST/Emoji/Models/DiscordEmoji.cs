using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Discord
{
    public class DiscordEmoji : PartialEmoji
    {
        public DiscordEmoji() => 
            OnClientUpdated += (sender, e) => Creator.SetClient(Client);

        [JsonProperty("user")]
        public DiscordUser Creator { get; private set; }

        [JsonProperty("available")]
        public bool Available { get; private set; }

        internal ulong GuildId { get; set; }
        public MinimalGuild Guild => new MinimalGuild(GuildId).SetClient(Client);

        private void Update(DiscordEmoji emoji) => Name = emoji.Name;

        /// <summary>
        /// Updates the emoji's info
        /// </summary>
        public void Update() => UpdateAsync().ToSync();

        /// <summary>
        /// Updates the emoji's info asynchronously
        /// </summary>
        public async Task UpdateAsync() => Update(await Client.GetGuildEmojiAsync(GuildId, (ulong) Id));


        /// <summary>
        /// Modifies the emoji
        /// </summary>
        /// <param name="name">New name</param>
        public void Modify(string name) => ModifyAsync(name).ToSync();

        /// <summary>
        /// Modifies the emoji asynchronously
        /// </summary>
        /// <param name="name">New name</param>
        public async Task ModifyAsync(string name) => Update(await Client.ModifyEmojiAsync(GuildId, (ulong) Id, name));

        /// <summary>
        /// Deletes the emoji
        /// </summary>
        public void Delete() => DeleteAsync().ToSync();

        /// <summary>
        /// Deletes the emoji asynchronously
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAsync() => await Client.DeleteEmojiAsync(GuildId, (ulong) Id);
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;
using ClassLibrary1;
using Newtonsoft.Json;

namespace BlizzStatistics.App.DataSource
{
    public class GameCharacters
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static GameCharacters Instance { get; } = new GameCharacters();

        /// <summary>
        /// The base URI
        /// </summary>
        private const string BaseUri = "http://localhost:59292/api/";

        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Prevents a default instance of the <see cref="GameCharacters"/> class from being created.
        /// </summary>
        private GameCharacters()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
            };
        }

        /// <summary>
        /// Gets the game characters.
        /// </summary>
        /// <returns></returns>
        public async Task<GameCharacter[]> GetGameCharacters()
        {
            var json = await _client.GetStringAsync("gameCharacters").ConfigureAwait(false);
            var gameCharacters = JsonConvert.DeserializeObject<GameCharacter[]>(json);
            return gameCharacters;
        }
    }
}

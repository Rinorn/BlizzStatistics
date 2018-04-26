using System;
using System.Net.Http;
using System.Threading.Tasks;
using ClassLibrary1;
using Newtonsoft.Json;

namespace BlizzStatistics.App.DataSource
{
    public class CharacterRaces
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static CharacterRaces Instance { get; } = new CharacterRaces();

        /// <summary>
        /// The base URI
        /// </summary>
        private const string BaseUri = "http://localhost:59292/api/";

        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Prevents a default instance of the <see cref="CharacterRaces"/> class from being created.
        /// </summary>
        private CharacterRaces()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
            };
        }

        /// <summary>
        /// Gets the character races.
        /// </summary>
        /// <returns></returns>
        public async Task<CharacterRace[]> GetCharacterRaces()
        {
            var json = await _client.GetStringAsync("characterRaces").ConfigureAwait(false);
            var characterRaces = JsonConvert.DeserializeObject<CharacterRace[]>(json);
            return characterRaces;
        }
    }
}

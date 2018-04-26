using System;
using System.Net.Http;
using System.Threading.Tasks;
using ClassLibrary1;
using Newtonsoft.Json;

namespace BlizzStatistics.App.DataSource
{
    public class CharacterClasses
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static CharacterClasses Instance { get; } = new CharacterClasses();

        /// <summary>
        /// The base URI
        /// </summary>
        private const string BaseUri = "http://localhost:59292/api/";

        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Prevents a default instance of the <see cref="CharacterClasses"/> class from being created.
        /// </summary>
        private CharacterClasses()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
            };
        }

        /// <summary>
        /// Gets the character classes.
        /// </summary>
        /// <returns></returns>
        public async Task<CharacterClass[]> GetCharacterClasses()
        {
            var json = await _client.GetStringAsync("characterClasses").ConfigureAwait(false);
            var characterClasseses = JsonConvert.DeserializeObject<CharacterClass[]>(json);
            return characterClasseses;
        }
    }
}

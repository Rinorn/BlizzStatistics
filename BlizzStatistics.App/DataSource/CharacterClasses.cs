using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using Newtonsoft.Json;

namespace BlizzStatistics.App.DataSource
{
    public class CharacterClasses
    {
        public static CharacterClasses Instance { get; } = new CharacterClasses();

        private const string baseUri = "http://localhost:59292/api/";

        HttpClient _client;

        private CharacterClasses()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<CharacterClass[]> GetCharacterClasses()
        {
            var json = await _client.GetStringAsync("characterClasses").ConfigureAwait(false);
            CharacterClass[] characterClasseses = JsonConvert.DeserializeObject<CharacterClass[]>(json);
            return characterClasseses;
        }
    }
}

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
    class CharacterRaces
    {
        public static CharacterRaces Instance { get; } = new CharacterRaces();

        private const string baseUri = "http://localhost:59292/api/";

        HttpClient _client;

        private CharacterRaces()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<CharacterRace[]> GetCharacterRaces()
        {
            var json = await _client.GetStringAsync("characterRaces").ConfigureAwait(false);
            CharacterRace[] characterRaces = JsonConvert.DeserializeObject<CharacterRace[]>(json);
            return characterRaces;
        }
    }
}

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
    class GameCharacters
    {
        public static GameCharacters Instance { get; } = new GameCharacters();

        private const string baseUri = "http://localhost:59292/api/";

        HttpClient _client;

        private GameCharacters()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        public async Task<GameCharacter[]> GetGameCharacters()
        {
            var json = await _client.GetStringAsync("gameCharacters").ConfigureAwait(false);
            GameCharacter[] gameCharacters = JsonConvert.DeserializeObject<GameCharacter[]>(json);
            return gameCharacters;
        }
    }
}

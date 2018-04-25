using System;
using System.Net.Http;
using System.Threading.Tasks;
using ClassLibrary1;
using Newtonsoft.Json;

namespace BlizzStatistics.App.DataSource
{
    class GameCharacters
    {
        public static GameCharacters Instance { get; } = new GameCharacters();

        private const string BaseUri = "http://localhost:59292/api/";

        HttpClient _client;

        private GameCharacters()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
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

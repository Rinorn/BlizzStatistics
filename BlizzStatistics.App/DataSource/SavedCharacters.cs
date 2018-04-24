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
    public class SavedCharacters
    {
        public static SavedCharacters Instance { get; } = new SavedCharacters();

        private const string BaseUri = "http://localhost:59292/api/";

        HttpClient _client;

        private SavedCharacters()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
            };
        }

        public async Task<SavedCharacter[]> GetSavedCharacter()
        {
            var json = await _client.GetStringAsync("savedCharacters").ConfigureAwait(false);
            SavedCharacter[] savedCharacters = JsonConvert.DeserializeObject<SavedCharacter[]>(json);
            return savedCharacters;
        }

        public async Task<bool> AddSavedCharacter(SavedCharacter character)
        {
            string postBody = JsonConvert.SerializeObject(character);
            var response = await _client.PostAsync("SavedCharacters", new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}

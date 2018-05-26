using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using Newtonsoft.Json;

namespace BlizzStatistics.App.DataSource
{
    public class SavedCharacters
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static SavedCharacters Instance { get; } = new SavedCharacters();

        /// <summary>
        /// The base URI
        /// </summary>
        private const string BaseUri = "http://localhost:59292/api/";

        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Prevents a default instance of the <see cref="SavedCharacters"/> class from being created.
        /// </summary>
        private SavedCharacters()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
            };
        }

        /// <summary>
        /// Gets the saved character.
        /// </summary>
        /// <returns></returns>
        public async Task<SavedCharacter[]> GetSavedCharacter()
        {
            var json = await _client.GetStringAsync("savedCharacters").ConfigureAwait(false);
            var savedCharacters = JsonConvert.DeserializeObject<SavedCharacter[]>(json);
            return savedCharacters;
        }

        /// <summary>
        /// Adds the saved character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        public async Task<bool> AddSavedCharacter(SavedCharacter character)
        {
            var postBody = JsonConvert.SerializeObject(character);
            var response = await _client.PostAsync("SavedCharacters", new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutSavedCharacter(SavedCharacter character)
        {
            var postBody = JsonConvert.SerializeObject(character);
            var respons = await _client.PutAsync($"SavedCharacters/{character.Id}",
                new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return respons.IsSuccessStatusCode;

        }
        public async Task<bool> DeleteSavedCharacter(SavedCharacter character)
        {
            var response = await _client.DeleteAsync($"SavedCharacters/{character.Id}").ConfigureAwait(false);
            return response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NotFound;
        }
    }
}

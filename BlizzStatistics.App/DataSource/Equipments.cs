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
    public class Equipments
    {
        public static Equipments Instance { get; } = new Equipments();

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
        private Equipments()
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
        public async Task<Equipment[]> GetEquipment()
        {
            var json = await _client.GetStringAsync("equipments").ConfigureAwait(false);
            var equipments = JsonConvert.DeserializeObject<Equipment[]>(json);
            return equipments;
        }
    }
}

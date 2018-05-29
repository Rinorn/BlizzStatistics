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
    public class Realms
    {
        public static Realms Instance { get; } = new Realms();

        /// <summary>
        /// The base URI
        /// </summary>
        private const string BaseUri = "http://localhost:59292/api/";

        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        
        /// </summary>
        private Realms()
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
        public async Task<Realm[]> GetRealm()
        {
            var json = await _client.GetStringAsync("realms").ConfigureAwait(false);
            var realms = JsonConvert.DeserializeObject<Realm[]>(json);
            return realms;
        }
    }
}

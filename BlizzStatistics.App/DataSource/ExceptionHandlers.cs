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
    public class ExceptionHandlers
    {
        public static ExceptionHandlers Instance { get; } = new ExceptionHandlers();

        private const string BaseUri = "http://localhost:59292/api/";

        private readonly HttpClient _client;

        private ExceptionHandlers()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
            };
        }

        public async Task<bool> AddExceptionHandler(ExceptionHandler exception)
        {
            var postBody = JsonConvert.SerializeObject(exception);
            var response = await _client.PostAsync("ExceptionHandlers", new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}

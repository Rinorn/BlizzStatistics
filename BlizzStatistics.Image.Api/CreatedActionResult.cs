using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BlizzStatistics.Image.Api
{
    public class CreatedActionResult : IHttpActionResult
    {
        /// <summary>
        /// The request
        /// </summary>
        private readonly HttpRequestMessage _request;
        /// <summary>
        /// The location
        /// </summary>
        private readonly string _location;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedActionResult"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="location">The location.</param>
        public CreatedActionResult(HttpRequestMessage request, string location)
        {
            _request = request;
            _location = location;
        }

        /// <summary>
        /// Creates an <see cref="T:System.Net.Http.HttpResponseMessage" /> asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that, when completed, contains the <see cref="T:System.Net.Http.HttpResponseMessage" />.
        /// </returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(_location);
            return Task.FromResult(response);
        }
    }
}
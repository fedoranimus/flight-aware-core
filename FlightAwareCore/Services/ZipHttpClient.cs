using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Flurl;

namespace FlightAware.Services
{
    /// <summary>
    /// An implementation of <see cref="HttpClient"/> that uses <see
    /// cref="DecompressionMethods.GZip"/> and <see cref="DecompressionMethods.Deflate"/>.
    /// </summary>
    public class ZipHttpClient
    {
        readonly string baseUri = string.Empty;
        static HttpClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipHttpClient"/> class.
        /// </summary>
        /// <param name="baseUri">The root domain and URL for making requests.</param>
        public ZipHttpClient(string baseUri, string username, string apiKey)
        {
            this.baseUri = baseUri;

            var handler = new HttpClientHandler();
            if(handler.SupportsAutomaticDecompression)
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            client = new HttpClient(handler);

            var credentials = Encoding.ASCII.GetBytes(username + ":" + apiKey);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
        }

        /// <summary>
        /// Make a request to the <see cref="baseUri"/> with <paramref name="requestString"/>
        /// concatenated to the end.
        /// </summary>
        /// <param name="requestString">
        /// The actual URL after the root domain to make the request to.
        /// </param>
        /// <returns>The <see cref="HttpRequestMessage"/> from the URL.</returns>
        public async Task<T> HttpRequest<T>(string endPoint, object values) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var uriBuilder = new UriBuilder(baseUri);
            var requestUrl = baseUri
                                .AppendPathSegment(endPoint)
                                .SetQueryParams(values);

            var response = await client.GetStreamAsync(requestUrl);
           return serializer.ReadObject(response) as T;
        }
    }
}
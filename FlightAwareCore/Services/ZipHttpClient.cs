using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlightAware.Services
{
    /// <summary>
    /// An implementation of <see cref="IHttpClient"/> that uses <see
    /// cref="DecompressionMethods.GZip"/> and <see cref="DecompressionMethods.Deflate"/>.
    /// </summary>
    public class ZipHttpClient : IHttpClient
    {
        readonly string baseUri = string.Empty;
        static HttpClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipHttpClient"/> class.
        /// </summary>
        /// <param name="baseUri">The root domain and URL for making requests.</param>
        public ZipHttpClient(string baseUri)
        {
            this.baseUri = baseUri;

            var handler = new HttpClientHandler();
            if(handler.SupportsAutomaticDecompression)
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            client = new HttpClient(handler);
        }

        /// <summary>
        /// Make a request to the <see cref="baseUri"/> with <paramref name="requestString"/>
        /// concatenated to the end.
        /// </summary>
        /// <param name="requestString">
        /// The actual URL after the root domain to make the request to.
        /// </param>
        /// <returns>The <see cref="HttpRequestMessage"/> from the URL.</returns>
        public async Task<HttpResponseMessage> HttpRequest(string requestString)
        {
            client.BaseAddress = new System.Uri(baseUri);
            return await client.GetAsync(requestString);
        }
    }
}
namespace Devpack.Extensions.Types
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> DeleteAsync(
            this HttpClient client, string requestUri, HttpContent content, CancellationToken cancellation)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Content = content,
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{client.BaseAddress}{requestUri}")
            };

            return client.SendAsync(requestMessage, cancellation);
        }
    }
}
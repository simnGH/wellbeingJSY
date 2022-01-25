namespace wellbeing
{
    using System.Diagnostics;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;

    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PatchAsJsonAsync<TData>(this HttpClient client, string requestUri, TData data)
        {
            HttpMethod method = new HttpMethod("PATCH");
            HttpRequestMessage request = new HttpRequestMessage(method, requestUri)
            {
                Content = new ObjectContent<TData>(data, new JsonMediaTypeFormatter(), "application/json"),
            };

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await client.SendAsync(request);
            }
            catch (TaskCanceledException e)
            {
                Debug.WriteLine("ERROR: " + e.ToString());
            }

            return response;
        }
    }
}

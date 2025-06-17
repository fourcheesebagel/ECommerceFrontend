namespace ClientLibrary.Helper
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public Task<HttpClient> GetPrivateClientAsync()
        {
            throw new NotImplementedException();
        }

        public HttpClient GetPublicClient()
        {
            throw new NotImplementedException();
        }
    }
}

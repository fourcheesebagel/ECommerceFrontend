﻿using System.Net.Http.Headers;

namespace ClientLibrary.Helper
{
    public class HttpClientHelper(IHttpClientFactory clientFactory, ITokenService tokenService) : IHttpClientHelper
    {
        public async Task<HttpClient> GetPrivateClientAsync()
        {
            var client = clientFactory.CreateClient(Constant.ApiClient.Name);
            string token = await tokenService.GetJWTTokenAsync(Constant.Cookie.Name);
            if (string.IsNullOrEmpty(token))
                return client;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constant.Authentication.Type, token);
            return client;
        }

        public HttpClient GetPublicClient()
        {
            return clientFactory.CreateClient(Constant.ApiClient.Name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGenClient
{
    public class TokenProvider
    {
        private static readonly SemaphoreSlim _accessTokenSemaphore = new SemaphoreSlim(1, 1);
        private static AccessToken? _accessToken = null;
        private readonly HttpClient _httpClient;
        private readonly string accountId = string.Empty;

        public TokenProvider()
        {
            _httpClient = new HttpClient();
        }

        public TokenProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string AuthorizationUrl() => $"https://api.keygen.sh/v1/accounts/{accountId}";

        public virtual async Task<AccessToken> GetAccessToken()
        {
            if (_accessToken is { Expired: false })
            {
                return _accessToken;
            }

            _accessToken = await FetchToken();
            return _accessToken;
        }

        private async Task<AccessToken> FetchToken()
        {
            try
            {
                await _accessTokenSemaphore.WaitAsync();

                if (_accessToken is { Expired: false })
                {
                    return _accessToken;
                }

                var tokenRequest = new HttpRequestMessage(HttpMethod.Post, AuthorizationUrl());
                tokenRequest.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["grant_type"] = "client_credentials",
                });

                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www.form-urlencoded");

                using var response = await _httpClient.SendAsync(tokenRequest, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();

                var t = System.Text.Json.JsonSerializer.Deserialize<AccessToken>(result);

                return t ?? throw new Exception("Deserialization of token failed.");
            }

            finally
            {
                _accessTokenSemaphore.Release(1);
            }
        }
    }
}

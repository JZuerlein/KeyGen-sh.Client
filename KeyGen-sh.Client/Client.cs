using DeviceId;
using KeyGenClient.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace KeyGenClient
{
    public class Client
    {
        private HttpClient _httpClient;
        private readonly string _account = string.Empty;

        public Client(HttpClient httpClient,
                      string account)
        {
            _account = account;

            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string ValidateLicenseKeyUrl() => $"https://api.keygen.sh/v1/accounts/{_account}/licenses/actions/validate-key";
        public string ActivateMachineUrl() => $"https://api.keygen.sh/v1/accounts/{_account}/machines";
        public string CheckOutLicenseUrl(string licenseKey, bool encrypt, bool includeEntitlements)
        {
            string url = $"https://api.keygen.sh/v1/accounts/{_account}/licenses/{licenseKey}/actions/check-out";

            if (encrypt || includeEntitlements)
            {
                url += "?";
            }

            if (encrypt)
            {
                url += "encrypt=1";
                if (includeEntitlements)
                {
                    url += "&";
                }
            }

            if (includeEntitlements)
            {
                url += "include=entitlements";
            }

            return url;
        }
        private string CheckInLicenseUrl(string licenseKey) => $"https://api.keygen.sh/v1/accounts/{_account}/licenses/{licenseKey}/actions/check-in";

        private async Task Post<T>(string url, string licenseKey, T requestMessage) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Authorization", $"License {licenseKey}");
            request.Content = JsonContent.Create<T>(requestMessage);

            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
        }

        private async Task<S> Post<S>(string url, string licenseKey) where S : class
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Authorization", $"License {licenseKey}");

            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<S>(responseContent);
            return result!;
        }

        private async Task<S> Post<T, S>(string url, T requestMessage) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = JsonContent.Create<T>(requestMessage);

            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<S>(responseContent);
            return result!;
        }

        private async Task<S> Post<T, S>(string url, string licenseKey, T requestMessage) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Authorization", $"License {licenseKey}");
            request.Content = JsonContent.Create<T>(requestMessage);

            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<S>(responseContent);
            return result!;
        }

        public string CreateFingerprint()
        {
            return _account + ":" +
                new DeviceIdBuilder().OnWindows(_ => _.AddMotherboardSerialNumber().AddSystemUuid().AddProcessorId())
                                     .OnLinux(_ => _.AddMotherboardSerialNumber().AddMachineId().AddCpuInfo())
                                     .OnMac(_ => _.AddSystemDriveSerialNumber().AddPlatformSerialNumber())
                                     .ToString();
        }

        public async Task<KeyGenClient.Models.Machine> ActivateMachine(ActivateMachineRequest request, string licenseKey)
        {
            return await Post<ActivateMachineRequest, Machine>(ActivateMachineUrl(), licenseKey, request);
        }

        public async Task<KeyGenClient.Models.License> ValidateLicense(ValidateLicenseByKeyRequest request)
        {
            return await Post<ValidateLicenseByKeyRequest, KeyGenClient.Models.License>(ValidateLicenseKeyUrl(), request);
        }

        public async Task<KeyGenClient.Models.LicenseFileResponse> CheckOutLicense(string licenseKey)
        {
            return await Post<LicenseFileResponse>(CheckOutLicenseUrl(licenseKey, true, true), licenseKey);
        }

        public async Task<KeyGenClient.Models.License> CheckInLicense(string licenseKey)
        {
            return await Post<KeyGenClient.Models.License>(CheckInLicenseUrl(licenseKey), licenseKey);
        }

    }
}

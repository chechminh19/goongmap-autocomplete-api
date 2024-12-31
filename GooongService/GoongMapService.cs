using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;

namespace GoongService
{
    public class GoongMapService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        public GoongMapService(IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = configuration["GoongMap:ApiKey"];
        }
        // limit: index, radius: area(km), compound: true-detail address, false-not
        public async Task<string> GetAutocompleteResults(string query, int limit = 5, int radius = 50, bool moreCompound = false)
        {
            
            var url = $"https://rsapi.goong.io/place/autocomplete?input={query}&limit={limit}&radius={radius}&more_compound={moreCompound}&api_key={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Error calling Goong API: {response.ReasonPhrase}");
            }
        }
    }
}


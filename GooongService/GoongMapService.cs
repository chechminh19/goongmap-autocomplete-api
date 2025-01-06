using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        public async Task<AutocompleteResponseDto> GetAutocompleteResults(string query, int? limit, int? radius, bool moreCompound = false)
        {
            
            var url = $"https://rsapi.goong.io/place/autocomplete?input={query}&limit={limit}&radius={radius}&more_compound={moreCompound}&api_key={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                //return await response.Content.ReadAsStringAsync();

                // Đọc kết quả JSON từ Goong API
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AutocompleteResponseDto>(responseData);
            }
            else
            {
                throw new Exception($"Error calling Goong API: {response.ReasonPhrase}");
            }
        }
    }
}


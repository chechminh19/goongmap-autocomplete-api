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

                // read response JSON from Autocomplete API
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AutocompleteResponseDto>(responseData);
            }
            else
            {
                throw new Exception($"Error calling Autocomplete API: {response.ReasonPhrase}");
            }
        }
        // change address to location latlng
        public async Task<ForwardGeocodeDTOResponse> ForwardGeocode(string address)
        {
            var url = $"https://rsapi.goong.io/geocode?address={address}&api_key={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // read response JSON from ForwardGeocode API
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ForwardGeocodeDTOResponse>(responseData);
            }
            else
            {
                throw new Exception($"Error calling ForwardGeocode API: {response.ReasonPhrase}");
            }
        }
        // change latlng to location address
        public async Task<ForwardGeocodeDTOResponse> ReverseGeocode(string latlng)
        {
            var url = $"https://rsapi.goong.io/geocode?latlng={latlng}&api_key={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // read response JSON from ReverseGeocode API
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ForwardGeocodeDTOResponse>(responseData);
            }
            else
            {
                throw new Exception($"Error calling ForwardGeocode API: {response.ReasonPhrase}");
            }
        }

    }
}


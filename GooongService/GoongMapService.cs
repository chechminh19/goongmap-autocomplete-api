using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace GoongService
{
    public class GoongMapService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly IMemoryCache _cache;
        public GoongMapService(IConfiguration configuration, HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _apiKey = configuration["GoongMap:ApiKey"];
            _cache = cache;
        }
        // limit: index, radius: area(km), compound: true-detail address, false-not
        public async Task<AutocompleteResponseDto> GetAutocompleteResults(string query, string location,int? limit, int? radius, bool moreCompound = false)
        {

            var cacheKey = $"autocomplete_{query}_{location}_{limit}_{radius}_{moreCompound}"; // create cache key

            // check cache
            if (!_cache.TryGetValue(cacheKey, out AutocompleteResponseDto cachedResult))
            {
                var url = $"https://rsapi.goong.io/place/autocomplete?input={query}&location={location}&limit={limit}&radius={radius}&more_compound={moreCompound}&api_key={_apiKey}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<AutocompleteResponseDto>(responseData);

                    // setup cache
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5));// value time
                    _cache.Set(cacheKey, result, cacheEntryOptions); // save cache

                    return result;
                }
                else
                {
                    throw new Exception($"Error calling Autocomplete API: {response.ReasonPhrase}");
                }
            }

            // cachedResult
            return cachedResult;
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


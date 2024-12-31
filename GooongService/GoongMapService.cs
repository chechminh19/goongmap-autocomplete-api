using System.Net.Http;
using System.Threading.Tasks;

namespace GoongService
{
    //private readonly HttpClient _httpClient;
    //public class GoongMapService(HttpClient httpClient)
    //{
    //    _httpClient = httpClient;
    //}
    //public async Task<string> GetAutocompleteResults(string query, double? latitude = null, double? longitude = null)
    //{
    //    var url = "https://rsapi.goong.io/place/autocomplete?input=aqua&location=10.700920276971795%2C%20106.73296613898738&limit=10&radius=10&api_key={YOUR_API_KEY}" + query;

    //    if (latitude.HasValue && longitude.HasValue)
    //    {
    //        url += "&location=" + latitude.Value + "," + longitude.Value;
    //    }

    //    var response = await _httpClient.GetAsync(url);

    //    if (response.IsSuccessStatusCode)
    //    {
    //        return await response.Content.ReadAsStringAsync();
    //    }
    //    else
    //    {
    //        throw new Exception($"Error calling Goong API: {response.ReasonPhrase}");
    //    }
    //}
}


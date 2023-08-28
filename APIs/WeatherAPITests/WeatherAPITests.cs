using Newtonsoft.Json.Linq;

namespace WeatherAPItests
{
    public class WeatherAPI
    {
        private readonly HttpClient _httpClient; // Create an instance of HttpClient to make API requests

        public WeatherAPI()
        {
            _httpClient = new HttpClient(); // Initialize the HttpClient instance
        }

        [Fact]
        public async Task TestApiCall_Success() //Test to verify API running
        {
            var response = await _httpClient.GetAsync("https://weatherapi-tdd.azurewebsites.net/api/myapi/hello"); // Send a GET request to the API
            response.EnsureSuccessStatusCode(); // Ensures that response is success: code 2xx
        }

        [Fact]
        public async Task _LocationStockholm() //Test to ensure that returned weather-city is Stockholm
        {
            var expectedCityName = "Stockholm";

            var response = await _httpClient.GetAsync("https://weatherapi-tdd.azurewebsites.net/weather");
            var content = await response.Content.ReadAsStringAsync(); //Reads response

            response.EnsureSuccessStatusCode(); // Check that the API call was successful

            var responseObject = JObject.Parse(content);
            var location = responseObject["location"];
            var cityName = location?["name"]?.ToString();

            Assert.Equal(expectedCityName, cityName); // Check that the returned city name is Stockholm
        }
    }
}
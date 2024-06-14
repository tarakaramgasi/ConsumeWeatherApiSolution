using Microsoft.Extensions.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
namespace DataAccessLayer
{
    public class WeatherServices : IWeatherServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WeatherServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public object GetWeatherDetails()
        {
            #region .NetFramework version of HttpClient
            //HttpClient httpClient = new HttpClient();
            //var url = "http://localhost:5257/WeatherForecast";
            //HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;
            //object response = responseMessage.Content.ReadAsAsync<object>().Result;
            //return response;
            #endregion

            #region .NetCore Version of HttpClient
            var url = "http://localhost:5257/WeatherForecast";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Headers =
                {
                    { HeaderNames.Accept, "application/json" },
                    { HeaderNames.UserAgent, "HttpRequestsSample" }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = httpClient.SendAsync(httpRequestMessage);
            var response =JsonConvert.SerializeObject(httpResponseMessage.Result.Content.ReadAsAsync<object>().Result);
            return response;
            #endregion
        }
    }
}

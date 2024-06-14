using System.Text.Json;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace DataAccessLayer
{
    public class WeatherServices : IWeatherServices
    {
        public object GetWeatherDetails()
        {
            HttpClient httpClient = new HttpClient();
            var url = "http://localhost:5257/WeatherForecast";
            HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;
            var response = JsonConvert.SerializeObject(responseMessage.Content.ReadAsAsync<object>().Result);
            return response;
        }
    }
}

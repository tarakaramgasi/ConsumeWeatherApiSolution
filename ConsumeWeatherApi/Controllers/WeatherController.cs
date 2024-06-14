using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;

namespace ConsumeWeatherApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class WeatherController : ControllerBase
    {
        private IWeatherServices _services = null!;
        public WeatherController(IWeatherServices services)
        {
            _services = services;
        }
        public object Get()
        {
            var response = _services.GetWeatherDetails();
            return response;
        }
    }
}

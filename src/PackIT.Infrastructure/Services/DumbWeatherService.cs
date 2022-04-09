using PackIT.Application.DTO;
using PackIT.Application.Services;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.Services
{
    public class DumbWeatherService : IWeatherService
    {
        public Task<WeatherDto> GetWeatherAsync(Localization localization)
            => Task.FromResult(new WeatherDto( new Random().Next(5,25)));
    }
}

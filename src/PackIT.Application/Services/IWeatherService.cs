using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Services
{
    public interface IWeatherService
    {
        Task<> GetWeatherAsync(Localization localization);
    }
}

﻿using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Application.Exceptions
{
    public class MissingLocalizationWeatherException : PackITException
    {
        public Localization Localization { get; }

        public MissingLocalizationWeatherException(Localization localization) 
            : base($"Couldn't fetch weather data for '{localization.City},{localization.Country}")
        {
            Localization = localization;
        }

    }
}

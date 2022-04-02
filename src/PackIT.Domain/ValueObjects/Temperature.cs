using PackIT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.ValueObjects
{
    public record Temperature
    {

        public double Value { get; }

        public Temperature(double value)
        {
            if (value is < -5 or > 50)
                throw new InvalidTemperatureException(value);
            Value = value  ;
        }

        public static implicit operator double (Temperature temp)
            => temp.Value;

        public static implicit operator Temperature(double temp)
            => new(temp);

    }
}

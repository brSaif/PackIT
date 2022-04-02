using PackIT.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class InvalidTemperatureException : PackITException
    {
        public double Temp { get; set; }
        public InvalidTemperatureException(double temp) : base($"Value '{temp}' is Invalid temperature")
        {
            Temp = temp;
        }
    }
}

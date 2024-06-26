﻿using PackIT.Domain.Const;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies
{
    public record PolicyData(TravelDays TravelDays,  PackIT.Domain.Const.Gender Gender,
        PackIT.Domain.ValueObjects.Temperature Temperature, Localization Localization);
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace HelloWorldWeb.Services
{
    public interface ITimeService
    {
        public DateTime Now();
    }
}

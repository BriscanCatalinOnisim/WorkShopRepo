// <copyright file="ITimeService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb.Services
{
    public interface ITimeService
    {
        public DateTime Now();
    }
#pragma warning restore SA1600 // Elements should be documented
}

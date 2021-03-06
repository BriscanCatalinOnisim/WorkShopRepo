// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
#pragma warning restore SA1600 // Elements should be documented
}

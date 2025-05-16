﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ICacheService
    {
        Task<string?> GetAsync(string cacheKey);
        Task SetAsync(string cacheKey, object value, TimeSpan timeToLive);
    }
}

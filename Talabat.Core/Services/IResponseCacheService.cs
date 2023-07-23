using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Services
{
    public interface IResponseCacheService
    {
        Task CachResponseAsync(string cachKey, object response, TimeSpan timeToLive);

        Task<string> GetCachedResponseAsync(string cachKey);
    }
}

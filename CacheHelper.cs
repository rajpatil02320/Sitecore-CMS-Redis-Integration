using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Kernel;
using SPJ.Foundation.Caching.Contracts;
using SPJ.Foundation.Caching.Provider;

namespace SPJ.Foundation.Caching
{
    public static class CacheHelper
    {
        public const int DefaultCacheDuration = 60;
        static ICache _memoryCache = new InMemoryProvider("SPJ", 60);
        static ICache _memoryLongCache = new InMemoryProvider("SPJ", Convert.ToInt32(Sitecore.Configuration.Settings.GetSetting("SPJ.LongCache.Duration", "10")));
        static ICache _sharedRedisCache = (ICache)Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService(typeof(IRedisProvider));
        static ICache _applicationCache = (ICache)Sitecore.DependencyInjection.ServiceLocator.ServiceProvider.GetService(typeof(ICache));


        /// <summary>
        /// The memory cache
        /// </summary>
        public static ICache MemoryCache => _memoryCache;

        /// <summary>
        /// The long memory cache
        /// </summary>
        public static ICache MemoryLongCache => _memoryLongCache;

        /// <summary>
        /// Gets the application cache.
        /// </summary>
        /// <value>
        /// The application cache.
        /// </value>
        public static ICache ApplicationCache => _applicationCache;

        public static ICache SharedRedisCache => _sharedRedisCache;

        public static void Clear()
        {
            MemoryLongCache?.Clear();
            MemoryCache?.Clear();
            ApplicationCache?.Clear();
        }
    }
}
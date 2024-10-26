using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPJ.Foundation.Caching
{
    public static class SessionCacheHelper
    {
        /// <summary>
        /// Get Session Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            var session = HttpContext.Current?.Session;
            if (null != session && session[key] != null)
            {
                return (T)session[key];
            }

            return default;
        }
        /// <summary>
        /// Set Session Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(string key, T value)
        {
            var session = HttpContext.Current?.Session;
            if (null != session && value != null)
            {
                session[key] = value;
            }
        }

        public static void Remove(string key)
        {
            var session = HttpContext.Current?.Session;
            if (null != session && session[key] != null)
            {
                session[key] = null;
            }
        }
    }
}
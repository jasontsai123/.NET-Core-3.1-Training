using System;

namespace Training2020WithNorthwind.Common.Infrastructure.Caching
{
    public interface ICacheProvider
    {
        /// <summary>
        /// 確認快取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(string key);

        /// <summary>
        /// 取得快取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 存入快取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        /// <returns></returns>
        bool Save<T>(string key, T value, TimeSpan cacheTime);
    }
}
using System;
using MessagePack;
using MessagePack.Resolvers;
using Microsoft.Extensions.Caching.Distributed;

namespace Training2020WithNorthwind.Common.Infrastructure.Caching
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IDistributedCache _distributedCache;
        /// <summary>
        /// Constructor for RedisCacheProvider.
        /// </summary>
        /// <param name="distributedCache"></param>
        public CacheProvider(IDistributedCache distributedCache)
        {
            this._distributedCache = distributedCache;
        }

        /// <summary>
        /// 確認快取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            var result = this._distributedCache.Get(key) != null;
            return result;
        }

        /// <summary>
        /// 取得快取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            var value = this._distributedCache.Get(key);

            var cachedValue = value != null
                ? MessagePackSerializer.Deserialize<T>(value, ContractlessStandardResolver.Options)
                : default(T);

            return cachedValue;
        }

        /// <summary>
        /// 存入快取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime"></param>
        /// <returns></returns>
        public bool Save<T>(string key, T value, TimeSpan cacheTime)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            bool result;

            try
            {
                this._distributedCache.Set
                (
                    key: key,
                    value: MessagePackSerializer.Serialize(value, ContractlessStandardResolver.Options),
                    options: new DistributedCacheEntryOptions
                    {
                        // set cache time
                        AbsoluteExpirationRelativeToNow = cacheTime
                    }
                );

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
    }
}
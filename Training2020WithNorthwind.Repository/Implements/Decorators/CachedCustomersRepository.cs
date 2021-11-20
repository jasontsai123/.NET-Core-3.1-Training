using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Training2020WithNorthwind.Common.Infrastructure.Attributes;
using Training2020WithNorthwind.Common.Infrastructure.Caching;
using Training2020WithNorthwind.Repository.Enities;
using Training2020WithNorthwind.Repository.Implements.Base;
using Training2020WithNorthwind.Repository.Implements.Interfaces;
using Training2020WithNorthwind.Repository.Infrastructure.Helpers.Interfaces;

namespace Training2020WithNorthwind.Repository.Implements.Decorators
{
    public class CachedCustomersRepository : BaseRepository, ICustomersRepository
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ICacheProvider _cacheProvider;
        public CachedCustomersRepository(IDatabaseHelper databaseHelper, ICustomersRepository customersRepository, ICacheProvider cacheProvider) : base(databaseHelper)
        {
            _customersRepository = customersRepository;
            _cacheProvider = cacheProvider;
        }

        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        /// <summary>
        /// 取得Customer所有資料表.
        /// </summary>
        /// <returns></returns>
        [CoreProfile("CachedCustomersRepository.GetAllAsync()")]
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            var cachekey = "GetAllCustomers";

            if (_cacheProvider.Exists(cachekey))
            {
                return _cacheProvider.Get<IEnumerable<Customers>>(cachekey);
            }

            await semaphoreSlim.WaitAsync();

            try
            {
                if (_cacheProvider.Exists(cachekey))
                {
                    return _cacheProvider.Get<IEnumerable<Customers>>(cachekey);
                }

                var result = await _customersRepository.GetAllAsync();
                _cacheProvider.Save(cachekey, result, TimeSpan.FromSeconds(30));

                return result;
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        /// <summary>
        /// 新增Customer資料
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>新增筆數</returns>
        [CoreProfile("CachedCustomersRepository.InsertAsync()")]
        public async Task<int> InsertAsync(Customers entity)
        {
            return await _customersRepository.InsertAsync(entity);
        }
    }
}
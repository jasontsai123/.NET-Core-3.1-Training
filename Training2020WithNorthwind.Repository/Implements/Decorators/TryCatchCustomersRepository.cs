using System.Collections.Generic;
using System.Threading.Tasks;
using Training2020WithNorthwind.Common.Infrastructure.Attributes;
using Training2020WithNorthwind.Repository.Enities;
using Training2020WithNorthwind.Repository.FakeData;
using Training2020WithNorthwind.Repository.Implements.Base;
using Training2020WithNorthwind.Repository.Implements.Interfaces;
using Training2020WithNorthwind.Repository.Infrastructure.Helpers.Interfaces;

namespace Training2020WithNorthwind.Repository.Implements.Decorators
{
    public class TryCatchCustomersRepository : BaseRepository, ICustomersRepository
    {
        private readonly ICustomersRepository _customersRepository;
        public TryCatchCustomersRepository(IDatabaseHelper databaseHelper, ICustomersRepository customersRepository) : base(databaseHelper)
        {
            _customersRepository = customersRepository;
        }

        /// <summary>
        /// 取得Customer所有資料表.
        /// </summary>
        /// <returns></returns>
        [CoreProfile("TryCatchCustomersRepository.GetAllAsync()")]
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            try
            {
                return await _customersRepository.GetAllAsync();
            }
            catch
            {
                //沒有DB則用假資料呈現
                return CustomerDataProvider.GetCustomerRepositoryAllData();
            }
        }

        /// <summary>
        /// 新增Customer資料
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>新增筆數</returns>
        [CoreProfile("TryCatchCustomersRepository.InsertAsync()")]
        public async Task<int> InsertAsync(Customers entity)
        {
            try
            {
                return await _customersRepository.InsertAsync(entity);
            }
            catch
            {
                return 0;
            }
        }
    }
}
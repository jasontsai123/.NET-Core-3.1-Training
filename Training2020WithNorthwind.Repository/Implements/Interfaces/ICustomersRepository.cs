using System.Collections.Generic;
using System.Threading.Tasks;
using Training2020WithNorthwind.Repository.Enities;

namespace Training2020WithNorthwind.Repository.Implements.Interfaces
{
    public interface ICustomersRepository
    {
        /// <summary>
        /// 取得Customer所有資料表.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customers>> GetAllAsync();

        /// <summary>
        /// 新增Customer資料
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>新增筆數</returns>
        Task<int> InsertAsync(Customers entity);
    }
}
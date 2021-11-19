using System.Collections.Generic;
using System.Threading.Tasks;
using Training2020WithNorthwind.Service.Dtos;

namespace Training2020WithNorthwind.Service.Implements.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Gets the customer All.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CustomerDto>> GetAllAsync();

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        Task<int> InsertAsync(CustomerDto dto);
    }
}
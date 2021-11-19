using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Training2020WithNorthwind.Common.Infrastructure.Attributes;
using Training2020WithNorthwind.Repository.Enities;
using Training2020WithNorthwind.Repository.Implements.Interfaces;
using Training2020WithNorthwind.Service.Dtos;
using Training2020WithNorthwind.Service.Implements.Interfaces;

namespace Training2020WithNorthwind.Service.Implements
{
    /// <summary>
    /// Customer服務層
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="customersRepository">The customers repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CustomerService(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the customer All.
        /// </summary>
        /// <returns></returns>
        [CoreProfile("CustomerService.GetAllAsync()")]
        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var data = await _customersRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<Customers>, IEnumerable<CustomerDto>>(data);
            return result;
        }

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public async Task<int> InsertAsync(CustomerDto dto)
        {
            var entity = _mapper.Map<CustomerDto, Customers>(dto);
            return await _customersRepository.InsertAsync(entity);
        }
    }
}
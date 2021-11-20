using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Training2020WithNorthwind.Application.Controllers.Models.Parameter;
using Training2020WithNorthwind.Application.Controllers.Models.ViewModel;
using Training2020WithNorthwind.Application.Infrastructure.ActionFilter;
using Training2020WithNorthwind.Application.Infrastructure.Validators.ParameterValidators;
using Training2020WithNorthwind.Service.Dtos;
using Training2020WithNorthwind.Service.Implements.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training2020WithNorthwind.Application.Controllers.v1
{
    /// <summary>
    /// 物件 控制器
    /// </summary>
    [Route("api/customer/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        /// <param name="mapper">The mapper.</param>
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await this._customerService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CustomerDto>, IEnumerable<CustomerViewModel>>(data);
            return Ok(result);
        }

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        [HttpPost]
        [RequestParameterValidator(typeof(CustomerParameterValidator))]
        public async Task<IActionResult> InsertAsync([FromBody]CustomerParameter parameter)
        {
            var dto = _mapper.Map<CustomerParameter, CustomerDto>(parameter);
            var result = await this._customerService.InsertAsync(dto);
            return Ok(result);
        }
    }
}
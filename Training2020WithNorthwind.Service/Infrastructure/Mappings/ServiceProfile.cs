using AutoMapper;
using Training2020WithNorthwind.Repository.Enities;
using Training2020WithNorthwind.Service.Dtos;

namespace Training2020WithNorthwind.Service.Infrastructure.Mappings
{
    /// <summary>
    /// 對映要新增的欄位
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ServiceProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProfile"/> class.
        /// </summary>
        public ServiceProfile()
        {
            CreateMap<Customers, CustomerDto>().ReverseMap();
        }
    }
}
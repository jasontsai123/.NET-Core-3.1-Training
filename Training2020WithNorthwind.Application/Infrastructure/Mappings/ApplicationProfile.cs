using AutoMapper;
using Training2020WithNorthwind.Application.Controllers.Models.Parameter;
using Training2020WithNorthwind.Application.Controllers.Models.ViewModel;
using Training2020WithNorthwind.Service.Dtos;

namespace Training2020WithNorthwind.Application.Infrastructure.Mappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CustomerDto, CustomerViewModel>();

            CreateMap<CustomerParameter, CustomerDto>();
        }
    }
}
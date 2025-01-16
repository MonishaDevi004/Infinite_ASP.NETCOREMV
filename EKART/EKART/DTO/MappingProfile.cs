using AutoMapper;
using EKART.Models;


namespace EKART.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();

        }
    }
}

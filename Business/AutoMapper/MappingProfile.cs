using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.Dtos;


namespace Business.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerUpdateDto, Customer>().ReverseMap();
            CreateMap<CustomerAddDto, Customer>().ReverseMap();
         

            CreateMap<TradeActivityAddDto, TradeActivity>().ReverseMap();
            CreateMap<TradeActivityUpdateDto, TradeActivity>().ReverseMap();

        }
    }
}

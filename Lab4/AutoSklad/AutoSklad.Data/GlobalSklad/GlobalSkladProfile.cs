using AutoMapper;

namespace AutoSklad.Data.GlobalSklad
{
    public class DaoGlobalSkladProfile : Profile
    {
        public DaoGlobalSkladProfile()
        {
            CreateMap<Core.GlobalSklad.GlobalSklad, GlobalSkladDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.NameOfThing, opt => opt.MapFrom(src => src.NameOfThing))
                .ReverseMap();
        }
    }
}
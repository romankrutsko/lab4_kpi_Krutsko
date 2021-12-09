using AutoMapper;

namespace AutoSklad.Orchestrators.GlobalSklad.Contract
{
    public class OrchGlobalSkladProfile : Profile
    {
        public OrchGlobalSkladProfile()
        {
            CreateMap<Core.GlobalSklad.GlobalSklad, GlobalSklad>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.NameOfThing, opt => opt.MapFrom(src => src.NameOfThing))
                .ReverseMap();
        }
    }

    public class GlobalSkladOrchProfile : Profile
    {
        public GlobalSkladOrchProfile()
        {
            CreateMap<Core.GlobalSklad.GlobalSklad, GlobalSklad>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.NameOfThing, opt => opt.MapFrom(src => src.NameOfThing))
                .ReverseMap();
        }
    }
}
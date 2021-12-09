using AutoMapper;

namespace AutoSklad.Orchestrators.LocalStore.Contract
{ 
    public class LocalStoreOrchProfile : Profile
    {
        public LocalStoreOrchProfile()
        {
            CreateMap<Core.LocalStore.LocalStore, LocalStore>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Naming, opt => opt.MapFrom(src => src.Naming))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.SkladId, opt => opt.MapFrom(src => src.SkladId))
                .ReverseMap();
        }
    }
}
using AutoMapper;

namespace AutoSklad.Data.LocalStore
{
    public class DaoLocalStoreProfile : Profile
    {
        public DaoLocalStoreProfile()
        {
            CreateMap<Core.LocalStore.LocalStore, LocalStoreDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Naming, opt => opt.MapFrom(src => src.Naming))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.SkladId, opt => opt.MapFrom(src => src.SkladId))
                .ReverseMap();
        }
    }
}
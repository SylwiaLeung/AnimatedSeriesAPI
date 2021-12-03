using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Models.DTO.Director;
using AnimatedSeriesAPI.Models.DTO.Episode;
using AutoMapper;

namespace AnimatedSeriesAPI.Models
{
    public class SerieMappingProfile : Profile
    {
        public SerieMappingProfile()
        {
            CreateMap<CastLector, CastLectorDto>()
                .ForMember(c => c.LectorName, c => c.MapFrom(c => c.Lector.Name));

            CreateMap<Director, DirectorLongDto>();
            CreateMap<Director, DirectorShortDto>();

            CreateMap<Serie, SerieShortDto>();
            CreateMap<Serie, SerieLongDto>()
                .ForMember(s => s.GenreName, s => s.MapFrom(s => s.Genre.Name));

            CreateMap<Season, SeasonLongDto>()
                .ForMember(s => s.SerieTitle, s => s.MapFrom(s => s.Serie.Title))
                .ForMember(s => s.DirectorName, s => s.MapFrom(s => s.Director.Name))
                .ForMember(s => s.Lectors, s => s.MapFrom(s => s.Cast.CastLectors));

            CreateMap<Season, SeasonShortDto>()
                .ForMember(s => s.SerieTitle, s => s.MapFrom(s => s.Serie.Title));

            CreateMap<Lector, LectorShortDto>();

            CreateMap<Genre, GenreShortDto>().ReverseMap();
            CreateMap<Genre, GenreLongDto>().ReverseMap();
            CreateMap<Genre, GenreCreateDto>().ReverseMap();
            CreateMap<Genre, GenreUpdateDto>().ReverseMap();

            CreateMap<Episode, EpisodeShortDto>();
            CreateMap<Episode, EpisodeLongDto>()
                .ForMember(s => s.SeasonNumber, s => s.MapFrom(s => s.Season.SeasonNumber));

            CreateMap<DirectorCreateDto, Director>().ReverseMap();
            CreateMap<DirectorUpdateDto, Director>().ReverseMap();
            CreateMap<EpisodeCreateDto, Episode>();
        }
    }
}
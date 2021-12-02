using AutoMapper;
using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Models.DTO.Director;
using AnimatedSeriesAPI.Models.DTO.Episode;

namespace AnimatedSeriesAPI.Models
{
    public class SerieMappingProfile : Profile
    {
        public SerieMappingProfile()
        {
            CreateMap<Director, DirectorLongDto>();
            CreateMap<Director, DirectorShortDto>();

            CreateMap<Serie, SerieShortDto>();
            CreateMap<Serie, SerieLongDto>()
                .ForMember(s => s.GenreName, s => s.MapFrom(s => s.Genre.Name));

            CreateMap<Season, SeasonLongDto>()
                .ForMember(s => s.SerieTitle, s => s.MapFrom(s => s.Serie.Title))
                .ForMember(s => s.DirectorName, s => s.MapFrom(s => s.Director.Name));
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
            CreateMap<EpisodeCreateDto, Episode>()
                .ForMember(s => s.Season, c => c.MapFrom(dto => new Season() { Id = dto.SeasonId }));
        }
    }
}
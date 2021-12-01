using AutoMapper;
using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Models.DTO.Director;

namespace AnimatedSeriesAPI.Models
{
    public class SerieMappingProfile : Profile
    {
        public SerieMappingProfile()
        {
            //CreateMap<Cast, CastShortDto>();

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

            CreateMap<Genre, GenreShortDto>();
            CreateMap<Genre, GenreLongDto>();

            CreateMap<Episode, EpisodeShortDto>();
            CreateMap<Episode, EpisodeLongDto>()
                .ForMember(s => s.SeasonNumber, s => s.MapFrom(s => s.Season.SeasonNumber));

            //CreateMap<LectorCreateDto, Lector>();
            CreateMap<DirectorCreateDto, Director>().ReverseMap();
            CreateMap<DirectorUpdateDto, Director>().ReverseMap();

            //CreateMap<SerieCreateDto, Serie>()
            //    .ForMember(s => s.Genre, c => c.MapFrom(dto => new Genre() { Id = dto.GenreId }));
            //CreateMap<SeasonCreateDto, Season>()
            //    .ForMember(s => s.Serie, c => c.MapFrom(dto => new Serie() { Id = dto.SerieId }))
            //    .ForMember(s => s.Cast, c => c.MapFrom(dto => new Cast() { Id = dto.CastId }))
            //    .ForMember(s => s.Director, c => c.MapFrom(dto => new Director() { Id = dto.DirectorId }));
            //CreateMap<GenreCreateDto, Genre>();
            //CreateMap<EpisodeCreateDto, Episode>()
            //    .ForMember(s => s.Season, c => c.MapFrom(dto => new Season() { Id = dto.SeasonId }));
            //CreateMap<CastCreateDto, Cast>();
        }
    }
}
namespace AnimatedSeriesAPI.Models
{
    public interface IGenreRepository : 
        IEditableRepository<GenreUpdateDto, GenreCreateDto>, 
        IReadableRepository<GenreLongDto, GenreShortDto>
    {
    }
}
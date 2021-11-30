namespace AnimatedSeriesAPI.Models
{
    public interface IGenreRepository : IEditableRepository<UpdateGenreDto, CreateGenreDto>, IReadableRepository<GenreLongDto, GenreShortDto>
    {
    }
}
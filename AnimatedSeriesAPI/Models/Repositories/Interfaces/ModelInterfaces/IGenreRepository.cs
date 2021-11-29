namespace AnimatedSeriesAPI.Controllers
{
    public interface IGenreRepository : IEditableRepository<UpdateGenreDto, CreateGenreDto>, IReadableRepository<GenreDto>
    {
    }
}
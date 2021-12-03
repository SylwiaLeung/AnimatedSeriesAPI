using AnimatedSeriesAPI.Entities;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface IGenreRepository :
        IEditableRepository<Genre, GenreCreateDto>,
        IReadableRepository<GenreLongDto, GenreShortDto>
    {
        Task<Genre> GetById(int id);
    }
}
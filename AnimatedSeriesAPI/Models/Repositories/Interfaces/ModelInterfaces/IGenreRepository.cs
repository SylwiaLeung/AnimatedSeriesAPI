using AnimatedSeriesAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface IGenreRepository : 
        IEditableRepository<Genre, GenreCreateDto>, 
        IReadableRepository<GenreLongDto, GenreShortDto>
    {
    }
}
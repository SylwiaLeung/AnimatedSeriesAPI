using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface IGenreRepository : 
        IEditableRepository<GenreUpdateDto, GenreCreateDto>, 
        IReadableRepository<GenreLongDto, GenreShortDto>
    {
    }
}
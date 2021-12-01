using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface ISeasonRepository
    {
        Task<IEnumerable<SeasonLongDto>> GetAll();
        Task<SeasonLongDto> GetSingle(int id);
    }
}
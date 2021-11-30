using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface IReadableRepository<T>
    {
        Task<T> GetSingle(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
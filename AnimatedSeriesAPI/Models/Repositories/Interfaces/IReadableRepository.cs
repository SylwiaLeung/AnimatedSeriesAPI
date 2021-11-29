using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    public interface IReadableRepository<T>
    {
        Task<T> GetSingle(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface IEditableRepository<T, U>
    {
        Task<int> Add(U obj);
        Task Delete(int id);
        Task Update(T obj, int id);
    }
}
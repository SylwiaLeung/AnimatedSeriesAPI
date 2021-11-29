using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    public interface IEditableRepository<T, U>
    {
        Task SaveAsyncChanges();
        Task<int> Add(U obj);
        Task Delete(int id);
        Task Update(T obj, int id);
    }
}
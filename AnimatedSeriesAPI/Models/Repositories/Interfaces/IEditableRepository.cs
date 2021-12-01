using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface IEditableRepository<T, U> where T : class
    {
        Task<int> Add(U obj);
        Task Delete(int id);
        Task Update(JsonPatchDocument<T> obj, int id);
    }
}
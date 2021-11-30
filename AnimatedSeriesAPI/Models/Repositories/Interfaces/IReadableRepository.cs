using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface IReadableRepository<L, S>
    {
        Task<L> GetSingle(int id);
        Task<IEnumerable<S>> GetAll();
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public interface IReadableRepository<L, S>
    {
        Task<ActionResult<L>> GetSingle(int id);
        Task<ActionResult<IEnumerable<S>>> GetAll();
    }
}
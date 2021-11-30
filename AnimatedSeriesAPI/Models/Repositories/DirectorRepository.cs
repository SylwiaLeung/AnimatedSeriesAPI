using AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        public Task<IEnumerable<DirectorShortDto>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<DirectorLongDto> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

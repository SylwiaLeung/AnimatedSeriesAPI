using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Controllers
{
    public class GenreRepository : IGenreRepository
    {
        public Task<int> Add(CreateGenreDto obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<GenreDto>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<GenreDto> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveAsyncChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(UpdateGenreDto obj, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
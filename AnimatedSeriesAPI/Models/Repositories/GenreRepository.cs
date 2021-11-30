using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
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

        public Task<IEnumerable<GenreShortDto>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<GenreShortDto> GetSingle(int id)
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
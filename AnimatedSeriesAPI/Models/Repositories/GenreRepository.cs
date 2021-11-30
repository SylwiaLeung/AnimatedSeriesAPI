using AnimatedSeriesAPI.Data;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public class GenreRepository : IGenreRepository
    {
        private readonly SeriesDbContext _context;
        private readonly IMapper _maper;

        public GenreRepository(SeriesDbContext context, IMapper mapper)
        {
            _context = context;
            _maper = mapper;
        }

        public Task<int> Add(GenreCreateDto obj)
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

        public Task<GenreLongDto> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveAsyncChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(GenreUpdateDto obj, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
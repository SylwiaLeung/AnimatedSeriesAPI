using AnimatedSeriesAPI.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public class GenreRepository : IGenreRepository
    {
        private readonly SeriesDbContext _context;
        private readonly IMapper _mapper;

        public GenreRepository(SeriesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<int> Add(GenreCreateDto obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<GenreShortDto>> GetAll()
        {
            var genres = await _context.Genres.ToListAsync();

            var genresDto = _mapper.Map<List<GenreShortDto>>(genres);

            return genresDto;
        }

        public async Task<GenreLongDto> GetSingle(int id)
        {
            var genre = await _context.Genres.Include(x => x.Series).FirstOrDefaultAsync(i => i.Id == id);

            var genreDto = _mapper.Map<GenreLongDto>(genre);

            return genreDto;
        }

        public Task Update(GenreUpdateDto obj, int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
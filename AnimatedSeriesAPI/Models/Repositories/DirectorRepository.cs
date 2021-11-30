using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly SeriesDbContext _context;
        private readonly IMapper _mapper;

        public DirectorRepository(SeriesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DirectorShortDto>> GetAll()
        {
            var listOfAllDirector = await _context.Directors.ToListAsync();
            return _mapper.Map<IEnumerable<DirectorShortDto>>(listOfAllDirector);
        }

        public async Task<DirectorLongDto> GetSingle(int id)
        {
            var director = await _context.Directors.Include(x =>x.Seasons).SingleOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<DirectorLongDto>(director);      
        }
    }
}

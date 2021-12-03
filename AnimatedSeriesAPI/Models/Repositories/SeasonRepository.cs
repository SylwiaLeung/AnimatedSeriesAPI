using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Exceptions;
using AnimatedSeriesAPI.Properties;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly SeriesDbContext _context;
        private readonly IMapper _mapper;

        public SeasonRepository(SeriesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SeasonShortDto>> GetAll()
        {
            var seasons = await _context
                .Seasons
                .ToListAsync();

            var seasonDtos = _mapper.Map<List<SeasonShortDto>>(seasons);

            return seasonDtos;
        }

        public async Task<SeasonLongDto> GetSingle(int id)
        {
            var season = await _context
                .Seasons
                .Include(x => x.Director)
                .Include(x => x.Episodes)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (season is null)
                throw new NotFoundException(Resources.ResourceManager.GetString("seasonNotFound"));

            var seasonDto = _mapper.Map<SeasonLongDto>(season);

            return seasonDto;
        }
    }
}

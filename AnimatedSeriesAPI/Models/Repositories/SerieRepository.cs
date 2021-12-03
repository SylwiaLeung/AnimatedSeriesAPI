using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Exceptions;
using AnimatedSeriesAPI.Properties;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public class SerieRepository : ISerieRepository
    {
        private readonly SeriesDbContext _context;
        private readonly IMapper _mapper;

        public SerieRepository(SeriesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<SerieLongDto>> GetAll(SeriesQuery query)
        {
            if (query.PageNumber == 0 || query.PageSize == 0)
                throw new NotFoundException(Resources.ResourceManager.GetString("noPageInfo"));

            var series = await _context
                .Series
                .Include(s => s.Genre)
                .Include(x => x.Seasons)
                .ToListAsync();

            var serieDtos = _mapper.Map<List<SerieLongDto>>(series);

            var baseQuery = serieDtos
                .Where(s => query.SearchPhrase == null
                || s.Title.ToLower().Contains(query.SearchPhrase.ToLower())
                || s.GenreName.ToLower().Contains(query.SearchPhrase.ToLower()));

            var filteredDtos = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var result = new PagedResult<SerieLongDto>(filteredDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }

        public async Task<SerieLongDto> GetSingle(int id)
        {
            var serie = await GetSerieAsync(id);

            if (serie is null)
                throw new NotFoundException(Resources.ResourceManager.GetString("serieNotFound"));

            var serieDto = _mapper.Map<SerieLongDto>(serie);

            return serieDto;
        }

        public async Task<IEnumerable<SeasonShortDto>> GetAllSeasons(int serieId)
        {
            var serie = await GetSerieAsync(serieId);

            var seasonDtos = _mapper.Map<List<SeasonShortDto>>(serie.Seasons);

            return seasonDtos;
        }

        public async Task<SeasonLongDto> GetSingleSeason(int serieId, int seasonId)
        {
            var serie = await GetSerieAsync(serieId);

            var season = await _context
                .Seasons
                .Include(s => s.Director)
                .Include(s => s.Episodes)
                .Include(s => s.Cast)
                .ThenInclude(c => c.CastLectors)
                .ThenInclude(c => c.Lector)
                .FirstOrDefaultAsync(d => d.Id == seasonId);

            if (season is null || season.SerieId != serieId)
                throw new NotFoundException(Resources.ResourceManager.GetString("seasonNotFound"));

            var seasonDto = _mapper.Map<SeasonLongDto>(season);

            return seasonDto;
        }

        private async Task<Serie> GetSerieAsync(int serieId)
        {
            var serie = await _context
                .Series
                .Include(s => s.Genre)
                .Include(x => x.Seasons)
                .FirstOrDefaultAsync(s => s.Id == serieId);

            if (serie is null)
                throw new NotFoundException(Resources.ResourceManager.GetString("serieNotFound"));

            return serie;
        }
    }
}

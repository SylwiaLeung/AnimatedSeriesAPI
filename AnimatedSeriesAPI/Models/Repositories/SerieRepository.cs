using AnimatedSeriesAPI.Controllers;
using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using AnimatedSeriesAPI.Exceptions;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<SerieShortDto>> GetAll()
        {
            var series = await _context
                .Series
                .ToListAsync();

            var serieDtos = _mapper.Map<List<SerieShortDto>>(series);

            return serieDtos;
        }

        public async Task<SerieLongDto> GetSingle(int id)
        {
            var serie = await GetSerieAsync(id);

            if (serie is null)
                throw new NotFoundException("Serie not found");

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
                .FirstOrDefaultAsync(d => d.Id == seasonId);

            if (season is null || season.SerieId != serieId)
                throw new NotFoundException("Season not found");

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
                throw new NotFoundException("Serie not found");

            return serie;
        }
    }
}

using AnimatedSeriesAPI.Controllers;
using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models
{
    public class SerieRepository : ISerieRepository
    {
        private readonly SeriesDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<SerieController> _logger;

        public SerieRepository(SeriesDbContext context, IMapper mapper, ILogger<SerieController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<SerieShortDto>> GetAll()
        {
            var series = await _context
                .Series
                .ToListAsync();

            var serieShortDtos = _mapper.Map<List<SerieShortDto>>(series);

            return serieShortDtos;
        }

        public async Task<SerieLongDto> GetSingle(int id)
        {
            var serie = await GetSerieAsync(id);

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
                .FirstOrDefaultAsync(g => g.Id == serieId);

            if (serie is null)
                throw new NotFoundException("Serie not found");

            return serie;
        }
    }
}

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
using System.Linq;

namespace AnimatedSeriesAPI.Models
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly SeriesDbContext _context;
        private readonly IMapper _mapper;

        public EpisodeRepository(SeriesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EpisodeShortDto>> GetAll(int serieId, int seasonId)
        {
            await GetSerieAsync(serieId);
            var season = await GetSeasonAsync(serieId, seasonId);

            var episodesInDb = season.Episodes;
            var episodeDtos = _mapper.Map<List<EpisodeShortDto>>(episodesInDb);

            return episodeDtos;
        }

        public async Task<EpisodeLongDto> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        private async Task<Serie> GetSerieAsync(int serieId)
        {
            var serie = await _context
                .Series
                .Include(x => x.Seasons)
                .FirstOrDefaultAsync(s => s.Id == serieId);

            if (serie is null)
                throw new NotFoundException("Serie not found");

            return serie;
        }

        private async Task<Season> GetSeasonAsync(int serieId, int seasonId)
        {
            var season = await _context
                .Seasons
                .Include(s => s.Episodes)
                .FirstOrDefaultAsync(d => d.Id == seasonId);

            if (season is null || season.SerieId != serieId)
                throw new NotFoundException("Season not found");

            return season;
        }
    }
}

using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AnimatedSeriesAPI.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AnimatedSeriesAPI.Properties;
using AnimatedSeriesAPI.Models.DTO.Episode;

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

        public async Task<EpisodeLongDto> GetSingle(int serieId, int seasonId, int episodeId)
        {
            await GetSerieAsync(serieId);
            var season = await GetSeasonAsync(serieId, seasonId);

            var episodeInDb = season.Episodes.FirstOrDefault(e => e.Id == episodeId);

            if (episodeInDb is null || season.SerieId != serieId || episodeInDb.SeasonId != seasonId)
                throw new NotFoundException(Resources.ResourceManager.GetString("episodeNotFound"));
            var episodeDto = _mapper.Map<EpisodeLongDto>(episodeInDb);

            return episodeDto;
        }

        private async Task<Serie> GetSerieAsync(int serieId)
        {
            var serie = await _context
                .Series
                .Include(x => x.Seasons)
                .FirstOrDefaultAsync(s => s.Id == serieId);

            if (serie is null)
                throw new NotFoundException(Resources.ResourceManager.GetString("serieNotFound"));

            return serie;
        }

        private async Task<Season> GetSeasonAsync(int serieId, int seasonId)
        {
            var season = await _context
                .Seasons
                .Include(s => s.Episodes)
                .FirstOrDefaultAsync(d => d.Id == seasonId);

            if (season is null || season.SerieId != serieId)
                throw new NotFoundException(Resources.ResourceManager.GetString("seasonNotFound"));

            return season;
        }

        public Task Update(Episode obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<Episode> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<EpisodeLongDto> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<EpisodeShortDto>> GetAll()
        {
            throw new System.NotImplementedException();
        }





        public async Task<int> Add(EpisodeCreateDto episodeCreateDto)
        {
            var episodeModel = _mapper.Map<Episode>(episodeCreateDto);
            return episodeModel.Id;
        }

        public async Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }



    }
}

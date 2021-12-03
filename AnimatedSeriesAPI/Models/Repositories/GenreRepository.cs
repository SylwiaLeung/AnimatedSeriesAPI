using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Exceptions;
using AnimatedSeriesAPI.Properties;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<int> Add(GenreCreateDto genreCreateDto)
        {
            var genreModel = _mapper.Map<Genre>(genreCreateDto);
            await _context.AddAsync(genreModel);
            await _context.SaveChangesAsync();

            return genreModel.Id;
        }

        public async Task Delete(int id)
        {
            var genreToDelete = await _context
                .Genres
                .FirstOrDefaultAsync(i => i.Id == id);

            if (genreToDelete is null)
                throw new NotFoundException(Resources.ResourceManager.GetString("genreNotFound"));

            _context.Genres.Remove(genreToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<GenreShortDto>> GetAll()
        {
            var genres = await _context.Genres.ToListAsync();

            var genresDto = _mapper.Map<List<GenreShortDto>>(genres);

            return genresDto;
        }

        public async Task<Genre> GetById(int id)
        {
            var genre = await _context.Genres
              .Include(x => x.Series)
              .FirstOrDefaultAsync(i => i.Id == id);

            if (genre is null || genre.Id != id)
                throw new NotFoundException(Resources.ResourceManager.GetString("genreNotFound"));

            return genre;
        }

        public async Task<GenreLongDto> GetSingle(int id)
        {
            var genre = await _context.Genres
                .Include(x => x.Series)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (genre is null || genre.Id != id)
                throw new NotFoundException(Resources.ResourceManager.GetString("genreNotFound"));

            var genreDto = _mapper.Map<GenreLongDto>(genre);

            return genreDto;
        }

        public async Task Update(Genre genreToUpdate)
        {

            if (genreToUpdate is null)
                throw new NotFoundException(Resources.ResourceManager.GetString("genreNotFound"));

            _context.Genres.Update(genreToUpdate);
            await _context.SaveChangesAsync();

        }
    }
}
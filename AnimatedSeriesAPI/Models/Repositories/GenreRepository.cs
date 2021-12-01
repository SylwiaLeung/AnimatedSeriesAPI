using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

        public async Task<int> Add(GenreCreateDto obj)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var genre = await _context
                .Genres
                .FirstOrDefaultAsync(i => i.Id == id);

            if (genre is null)
                throw new NotFoundException("Genre not found");

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<GenreShortDto>> GetAll()
        {
            var genres = await _context.Genres.ToListAsync();

            if (genres is null)
                throw new NotFoundException("Genres not found");

            var genresDto = _mapper.Map<List<GenreShortDto>>(genres);

            return genresDto;
        }

        public async Task<GenreLongDto> GetSingle(int id)
        {
            var genre = await _context.Genres
                .Include(x => x.Series)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (genre is null || genre.Id != id)
                throw new NotFoundException("Genre not found");

            var genreDto = _mapper.Map<GenreLongDto>(genre);

            return genreDto;
        }

        public async Task Update(JsonPatchDocument<GenreUpdateDto> patchDoc, int id)
        {
            var genreModelToUpdate = await _context.Genres
                .FirstOrDefaultAsync(i => i.Id == id);
            if (genreModelToUpdate is null)
                throw new NotFoundException("Genre not found");


            var genreDtoToPatch = _mapper.Map<GenreUpdateDto>(genreModelToUpdate);

            patchDoc.ApplyTo(genreDtoToPatch);

            _mapper.Map(genreDtoToPatch, genreModelToUpdate);

            //if (!TryValidateModel(authorToPatch))
            //{
            //    return ValidationProblem(ModelState);
            //}

            _context.Genres.Update(genreModelToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
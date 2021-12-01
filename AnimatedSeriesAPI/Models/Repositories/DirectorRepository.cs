using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Exceptions;
using AnimatedSeriesAPI.Models.DTO.Director;
using AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<Director> listOfAllDirector = await _context.Directors.ToListAsync();

            if(listOfAllDirector is null)
            {
                throw new NotFoundException("Directors not found");
            }
            return _mapper.Map<IEnumerable<DirectorShortDto>>(listOfAllDirector);
        }

        public async Task<DirectorLongDto> GetSingle(int id)
        {
            var director = await _context.Directors.Include(x => x.Seasons).ThenInclude(x =>x.Serie).SingleOrDefaultAsync(x => x.Id == id);
            if (director is null)
            {
                throw new NotFoundException("Director not found");
            }
            return _mapper.Map<DirectorLongDto>(director);
        }

        public async Task<IEnumerable<SeasonShortDto>> GetDirectorAllSeasons(int directorId)
        {

            var director = await _context.Directors.Include(x =>x.Seasons).ThenInclude(x => x.Serie).SingleOrDefaultAsync(x =>x.Id == directorId);
            if (director is null)
            {
                throw new NotFoundException("Director not found");
            }
            var listOfDirectorSeasons = director.Seasons.ToList();
            if (listOfDirectorSeasons is null)
            {
                throw new NotFoundException("Director's seasons not found");
            }

            return _mapper.Map<IEnumerable<SeasonShortDto>>(listOfDirectorSeasons);
        }

        public async Task<int> Add(DirectorCreateDto directorCreateDto)
        {
            var directorModel = _mapper.Map<Director>(directorCreateDto);
            await _context.AddAsync(directorModel);
            await _context.SaveChangesAsync();

            return directorModel.Id;
        }

        public async Task Delete(int id)
        {
            var directorToDelete = await _context.Directors.FirstOrDefaultAsync(x => x.Id == id);
            if (directorToDelete is null)
            {
                throw new NotFoundException("Director not found");
            }

            _context.Directors.Remove(directorToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task Update(JsonPatchDocument<DirectorUpdateDto> patchDoc, int id)
        {
            var directorToUpdate = await _context.Directors.FirstOrDefaultAsync(x =>x.Id == id);
            if (directorToUpdate is null)
            {
                throw new NotFoundException("Director not found");
            }

            var directorToPatch = _mapper.Map<DirectorUpdateDto>(directorToUpdate);
            patchDoc.ApplyTo(directorToPatch);

            _mapper.Map(directorToPatch, directorToUpdate);

            //if(directorToUpdate is null)
            //{
            //    throw BadRequestResult("Updating value is null");
            //}

            _context.Directors.Update(directorToUpdate);
            await _context.SaveChangesAsync();
        }

    }
}

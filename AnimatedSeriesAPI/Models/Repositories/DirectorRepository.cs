using AnimatedSeriesAPI.Data;
using AnimatedSeriesAPI.Entities;
using AnimatedSeriesAPI.Exceptions;
using AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces;
using AutoMapper;
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
            return _mapper.Map<DirectorLongDto>(director);
        }

        public async Task<IEnumerable<SeasonShortDto>> GetDirectorAllSeasons(int directorId)
        {

            var director = await _context.Directors.Include(x =>x.Seasons).ThenInclude(x => x.Serie).SingleOrDefaultAsync(x =>x.Id == directorId);
            var listOfDirectorSeasons = director.Seasons.ToList();

            return _mapper.Map<IEnumerable<SeasonShortDto>>(listOfDirectorSeasons);
        }


    }
}

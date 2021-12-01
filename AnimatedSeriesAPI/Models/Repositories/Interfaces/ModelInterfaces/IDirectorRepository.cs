using AnimatedSeriesAPI.Models.DTO.Director;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces
{
    public interface IDirectorRepository : IReadableRepository<DirectorLongDto,DirectorShortDto>, IEditableRepository<DirectorUpdateDto, DirectorCreateDto>
    {
        Task<IEnumerable<SeasonShortDto>> GetDirectorAllSeasons(int directorId);
    }
}

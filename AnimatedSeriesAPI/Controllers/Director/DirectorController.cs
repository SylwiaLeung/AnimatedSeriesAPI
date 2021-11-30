using AnimatedSeriesAPI.Models.Repositories.Interfaces.ModelInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimatedSeriesAPI.Controllers.Director
{
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private IDirectorRepository _directorRepo;

        public DirectorController(IDirectorRepository directorRepo)
        {
            _directorRepo = directorRepo;
        }

        //[HttpGet]
        //[Route("/directors/")]
        

    }
}

using AnimatedSeriesAPI.Models;
using AnimatedSeriesAPI.Models.Repositories;
using System.Threading.Tasks;

namespace MusicAPI.Controllers
{
    public interface IAccountRepository
    {
        Task RegisterUser(RegisterUserDto dto);
        Task<string> GenerateJwt(LoginDto dto);
    } 
}
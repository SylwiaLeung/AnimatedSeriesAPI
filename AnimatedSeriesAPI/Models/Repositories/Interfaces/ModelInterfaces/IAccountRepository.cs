using System.Threading.Tasks;

namespace AnimatedSeriesAPI.Models.Repositories
{
    public interface IAccountRepository
    {
        Task RegisterUser(RegisterUserDto dto);
        Task<string> GenerateJwt(LoginDto dto);
    } 
}
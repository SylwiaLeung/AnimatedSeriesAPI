using AnimatedSeriesAPI.Models;
using AnimatedSeriesAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MusicAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountService;

        public AccountController(IAccountRepository accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// POST method register new account and add to database
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Return endpoint to new object</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "New Director"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns endpoint to new director</response>
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            await _accountService.RegisterUser(dto);

            return Ok();
        }

        /// <summary>
        /// POST method pass user login
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Returns JWT token</returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "name": "New Director"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns jwt token</response>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            string token = await _accountService.GenerateJwt(dto);

            return Ok(token);
        }
    }
}
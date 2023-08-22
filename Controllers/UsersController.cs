using Api_backend_university.DTO;
using Api_backend_university.Helpers;
using Api_backend_university.SecurityJWT;
using Api_backend_university.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_backend_university.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;

        public UsersController(IUser user)
        {
            _user = user;
        }

        /// <summary>
        /// Registrar usuario
        /// </summary>
        /// <returns>Id del usuario nuevo</returns>
        /// <response code="200"> Exito </response>
        /// <response code="500">Ha ocurrido un error a la hora de obtener la imagen.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegister userNew)
        {
            Answer response = new Answer();
            try
            {
                if (userNew == null)
                {
                    response.Success = false;
                    response.Message = "User not";
                    return BadRequest();
                }
                int IdUser = await _user.Register(userNew);
                if (IdUser > 0)
                {
                    response.Success = true;
                    response.Message = "user register";
                    response.Data = new {IdUser = IdUser};
                }else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    response.Message = ex.Message); ;
            }
            return Ok(response);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <returns>Token e información</returns>
        /// <response code="200"> Exito </response>
        /// <response code="500">Ha ocurrido un error en la creación.</response>
        [HttpPost("Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            Answer response = new Answer();
            try
            {
                if (login == null)
                {
                    response.Success = false;
                    response.Message = "Data not valid";
                    return BadRequest();
                }
                UserTokens validUser = await _user.ValidateCredentials(login);
                if ( validUser != null)
                {
                    response.Success = true;
                    response.Message = "user finded";
                    response.Data = validUser;
                }
                else
                {
                    return BadRequest(response.Message = "Credentials incorrect");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    response.Message = ex.Message); ;
            }
            return Ok(response);
        }

        /// <summary>
        /// Obtener todos las usuarios
        /// </summary>
        /// <param name=""></param>
        /// <returns>Catalogo de usuarios</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = DataRoles.ADMINISTRATOR)]
        public async Task<IActionResult> GetAllUsers()
        {
            Answer answer = new Answer();
            try
            {
                List<User> users = await _user.GetAllUsers();   

                if (users != null)
                {
                    answer.Success = true;
                    answer.Message = "Search succes";
                    answer.Data = users;
                }
                else
                {
                    answer.Success = false;
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(answer);
        }
    }
}

using Api_backend_university.Helpers;
using Api_backend_university.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_backend_university.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoles _roles;

        public RolesController(IRoles roles)
        {
            _roles = roles;
        }


        /// <summary>
        /// Obtener catalogo de roles
        /// </summary>
        /// <param name=""></param>
        /// <returns>Catalogo de los roles con su Id</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllRoles()
        {
            Answer answer = new Answer();
            try
            {
                List<Role> roles = await _roles.GetAllRoles();

                if (roles != null)
                {
                    answer.Success = true;
                    answer.Message = "Search succes";
                    answer.Data = roles;
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

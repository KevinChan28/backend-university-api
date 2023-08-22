using Api_backend_university.DTO;
using Api_backend_university.Helpers;
using Api_backend_university.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_backend_university.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CareersController : ControllerBase
    {
        private readonly ICareer _career;

        public CareersController(ICareer career)
        {
            _career = career;
        }

        /// <summary>
        /// Registrar una carrera
        /// </summary>
        /// <returns>Id de la carrera nuevo</returns>
        /// <response code="200"> Exito </response>
        /// <response code="500">Ha ocurrido un error en la creación.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = DataRoles.ADMINISTRATOR)]
        public async Task<IActionResult> RegisterCareer([FromBody] CareerRegister model)
        {
            Answer response = new Answer();
            try
            {
                if (model == null)
                {
                    response.Success = false;
                    response.Message = "Not data";
                    return BadRequest();
                }
                int idCareer = await _career.Register(model);
                if (idCareer > 0)
                {
                    response.Success = true;
                    response.Message = "Registered";
                    response.Data = new { IdCareer = idCareer };
                }
                else
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
        /// Obtener todas las carreras
        /// </summary>
        /// <param name=""></param>
        /// <returns>Catalogo de las carreras</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = DataRoles.ADMINISTRATOR)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllCareers()
        {
            Answer answer = new Answer();
            try
            {
              List<Career> careers = await _career.GetAllCareers();

                if (careers != null)
                {
                   answer.Success = true;
                   answer.Message = "Search succes";
                   answer.Data = careers;
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

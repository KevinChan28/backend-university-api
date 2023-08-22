using Api_backend_university.DTO;
using Api_backend_university.Helpers;
using Api_backend_university.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace Api_backend_university.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacher _teacher;

        public TeachersController(ITeacher teacher)
        {
            _teacher = teacher;
        }


        /// <summary>
        /// Registrar un maestro(a)
        /// </summary>
        /// <returns>Id del maestro(a) nuevo</returns>
        /// <response code="200"> Exito </response>
        /// <response code="500">Ha ocurrido un error en la creación.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = DataRoles.ADMINISTRATOR)]
        public async Task<IActionResult> RegisterTeacher([FromBody] TeacherRegister model)
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
                int IdTeacher = await _teacher.RegisterTeacher(model);

                if (IdTeacher > 0)
                {
                    response.Success = true;
                    response.Message = "Registered";
                    response.Data = new { IdTeacher = IdTeacher };
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
        /// Obtener todos los maestros
        /// </summary>
        /// <param name=""></param>
        /// <returns>Catalogo de los maestros</returns>
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = DataRoles.ADMINISTRATOR)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllCareers()
        {
            Answer answer = new Answer();
            try
            {
                List<TeacherInformation> careers = await _teacher.GetAllTeachers();

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

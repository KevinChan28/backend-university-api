using Api_backend_university.DTO;
using Api_backend_university.Helpers;
using Api_backend_university.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_backend_university.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourse _course;

        public CoursesController(ICourse course)
        {
            _course = course;
        }

        /// <summary>
        /// Registrar un curso
        /// </summary>
        /// <returns>Id de la curso nuevo</returns>
        /// <response code="200"> Exito </response>
        /// <response code="500">Ha ocurrido un error en la creación.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = DataRoles.ADMINISTRATOR)]
        public async Task<IActionResult> RegisterCourse([FromBody] CourseRegister model)
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
                int idCourse = await _course.RegisterCourse(model);
                if (idCourse > 0)
                {
                    response.Success = true;
                    response.Message = "Registered";
                    response.Data = new { IdCourse = idCourse };
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
        /// Obtener todas los cursos
        /// </summary>
        /// <param name=""></param>
        /// <returns>Catalogo de los cursos</returns>
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
                List<InformationCourse> courses = await _course.GetAllCourses();

                if (courses != null & courses.Count() > 0)
                {
                    answer.Success = true;
                    answer.Message = "Search succes";
                    answer.Data = courses;
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

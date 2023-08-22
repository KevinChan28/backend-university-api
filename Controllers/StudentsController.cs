using Api_backend_university.DTO;
using Api_backend_university.Helpers;
using Api_backend_university.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_backend_university.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _student;
        private readonly IInscription _inscription;

        public StudentsController(IStudent student, IInscription inscription)
        {
            _student = student;
            _inscription = inscription;
        }


        /// <summary>
        /// Registrar estudiante
        /// </summary>
        /// <returns>Id del estudiante nuevo</returns>
        /// <response code="200"> Exito </response>
        /// <response code="500">Ha ocurrido un error en la creación.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> StudentRegister([FromBody] StudentRegister model)
        {
            Answer response = new Answer();
            try
            {
                if (model == null && model.User == null)
                {
                    response.Success = false;
                    response.Message = "Data not valid";
                    return BadRequest();
                }
                int studentId = await _student.Register(model);

                if (studentId > 0)
                {
                    response.Success = true;
                    response.Message = "user finded";
                    response.Data = new {StudentId = studentId} ;
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
        /// Obtener todos los estudiantes con sus carreras
        /// </summary>
        /// <param name=""></param>
        /// <returns>Catalogo de studiantes con sus carreras</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllStudentsWithCareer()
        {
            Answer answer = new Answer();
            try
            {
                List<StudentsWithCareer> students = await _student.GetAllStudentsWithCareer();

                if (students != null)
                {
                    answer.Success = true;
                    answer.Message = "Search succes";
                    answer.Data = students;
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

        /// <summary>
        /// Obtener todos los estudiantes de una carrera
        /// </summary>
        /// <param name=""></param>
        /// <returns>Catalogo de studiantes de una carrera</returns>
        [HttpGet("{idCareer}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllStudentsOfOneCareer(int idCareer)
        {
            Answer answer = new Answer();
            try
            {
                List<StudentsWithCareer> students = await _student.GetAllStudentsByCareer(idCareer);

                if (students != null && students.Count() > 0)
                {
                    answer.Success = true;
                    answer.Message = "Search succes";
                    answer.Data = students;
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(answer);
        }

        /// <summary>
        /// Inscribir estudiante a un curso
        /// </summary>
        /// <returns>Id de la inscripcion</returns>
        /// <response code="200"> Exito </response>
        /// <response code="500">Ha ocurrido un error en la creación.</response>
        [HttpPost("EnrollInCourse")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AddStudentToCourse([FromBody] InscriptionRegister model)
        {
            Answer response = new Answer();
            try
            {
                ArgumentNullException.ThrowIfNull(nameof(model));
                int inscriptionId = await _inscription.AddStudentToCourse(model);

                if (inscriptionId > 0)
                {
                    response.Success = true;
                    response.Message = "inscription register";
                    response.Data = new { InscriptionId = inscriptionId };
                }
                else
                {
                    response.Message = "Inscription not register";
                    response.Success = false;
                    return BadRequest(response);
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
        /// Obtener todos los cursos de un estudiante
        /// </summary>
        /// <param name=""></param>
        /// <returns>Catalogo de cursos de un estudiante</returns>
        [HttpGet("StudentCourses/{idStudent}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetCoursesStudent(int idStudent)
        {
            Answer answer = new Answer();
            try
            {
                if (idStudent < 1)
                {
                    return BadRequest();
                }
                List<ClassInformation> courses = await _inscription.GetAllCoursesToStudent(idStudent);

                if (courses != null && courses.Count() > 0)
                {
                    answer.Success = true;
                    answer.Message = "Search succes";
                    answer.Data = courses;
                }
                else
                {
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

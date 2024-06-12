using Microsoft.AspNetCore.Mvc;
using WebAPICICD.Entities;
using WebAPICICD.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPICICD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            var students = _studentService.GetStudents();
            return Ok(students);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            var students = _studentService.GetStudents();
            student.Id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
            _studentService.Add(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student student)
        {
            _studentService.Update(student);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _studentService.Delete(id); 
        }
    }
}

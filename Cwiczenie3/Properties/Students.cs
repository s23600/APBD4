using Cwiczenie3;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia3
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGetStudent _getStudent;

        public StudentController(IGetStudent getStudent)
        {
            _getStudent = getStudent;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetStudents([FromQuery] string name)
        {
            IList<Student> students = await _getStudent.GetStudentsListAsync(name);
            return Ok(students);
        }
    }
}

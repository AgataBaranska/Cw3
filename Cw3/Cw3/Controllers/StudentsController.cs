using System;
using System.Linq;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        //dodana metoda odpowiadająca na żądanie typu DELETE
        [HttpDelete("{id}")]
        public IActionResult deleteStudent(int id)
        { 
            var student = _dbService.GetStudent(id);
            if (student == null) return NotFound($"Studenta o podanym id: { id} nie ma w bazie");
            _dbService.RemoveStudent(id);
            return Ok("Usuwanie ukończone");
        }

        //dodana metoda odpowiadająca na żądanie typu PUT
        [HttpPut("{id}")]
        public IActionResult updateStudent(int id,[FromBody] Student newStudent)
        {
            var student = _dbService.GetStudent(id);
            if (student == null) return NotFound($"Student o podanym {id} nie znajduje się w bazie");
            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;

            return Ok($"Aktualizacja dokończona : {student}");
        }



        //2.przekazanie za pomocą Query Stringa
        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            if (orderBy == "lastname")
            {
                return Ok(_dbService.GetStudents().OrderBy(s => s.LastName));
            
            }
            return Ok(_dbService.GetStudents());
        }


       
        // URL segment
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _dbService.GetStudent(id);
            if(student == null) return NotFound( $"W bazie nie ma studenta o id: {id}");
            return Ok(student);
        }

        //3. Body - ciało zadania
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {

            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            //...
            return Ok(student);
        }






    }
}

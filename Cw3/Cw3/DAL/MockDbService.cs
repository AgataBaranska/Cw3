using Cw3.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;



namespace Cw3.DAL
{
    public class MockDbService:IDbService
    {


        private static ICollection<Student> _students = new List<Student>
        {

            new Student{IdStudent = 1, FirstName = "Jan", LastName = "Kowalski", IndexNumber="s10293"},
            new Student{IdStudent = 2, FirstName = "Roman", LastName = "Malewski", IndexNumber="s12342"},
            new Student{IdStudent = 3, FirstName = "Bogdan", LastName = "Andrzejewicz", IndexNumber="s10457"}
        };

        public void AddStudent(Student studentToAdd)
        {
            if (_students.Count(student => studentToAdd.IndexNumber == student.IndexNumber) > 0)
                throw new DataException($"Student o podanym {studentToAdd.IndexNumber} jest już w bazie");

            _students.Add(studentToAdd);
        }

        public Student GetStudent(int id)
        {
            var student = _students.Where(student => student.IdStudent == id);
            if (!student.Any()) return null;
            return student.ToList().First();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students; 
        }

        public void RemoveStudent(int id)
        {
            var student = _students.Where(student => student.IdStudent == id).ToList().First();
            _students.Remove(student);
        }
    }
}

using Cw3.Models;
using System.Collections.Generic;


namespace Cw3.DAL
{
   public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(int id);
        public void AddStudent(Student studentToAdd);
        public void RemoveStudent(int id);


    }
}

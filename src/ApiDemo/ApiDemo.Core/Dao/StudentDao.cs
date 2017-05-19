using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDemo.Core.Entities;
using ApiDemo.Core.EntityFramework;

namespace ApiDemo.Core.Dao
{
    public class StudentDao : IStudentDao
    {
        public bool Insert(Student student)
        {
            using (var ctx = new DemoContext())
            {
                ctx.Students.Add(student);
                return ctx.SaveChanges() > 0;
            }
        }

        public Student Get(int id)
        {
            using (var ctx = new DemoContext())
            {
               return  ctx.Students.First(p => p.Id == id);
            }
        }

        public IList<Student> GetStudents(Func<Student, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}

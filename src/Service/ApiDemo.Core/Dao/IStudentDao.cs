using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDemo.Core.Entities;

namespace ApiDemo.Core.Dao
{
    public interface IStudentDao
    {
        bool Insert(Student student);

        Student Get(int id);

        IList<Student> GetStudents(Func<Student, bool> func);

        bool Delete(int id);
    }
}

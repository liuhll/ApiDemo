using System;
using System.Collections.Generic;
using ApiDemo.Core.Entities;

namespace ApiDemo.Core.AppService
{
    public interface IStudentAppService
    {
        bool Insert(Student student);

        Student Get(int id);

        IList<Student> GetStudents(Func<Student, bool> func);
    }
}
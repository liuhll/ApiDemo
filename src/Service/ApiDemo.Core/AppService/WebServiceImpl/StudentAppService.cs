using System;
using System.Collections.Generic;
using ApiDemo.Core.Dao;
using ApiDemo.Core.Entities;

namespace ApiDemo.Core.AppService.WebServiceImpl
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentDao _studentDao;

        public StudentAppService()
        {
            _studentDao = new StudentDao();
        }

        public bool Insert(Student student)
        {
            return _studentDao.Insert(student);
        }

        public Student Get(int id)
        {
            return _studentDao.Get(id);
        }

        public IList<Student> GetStudents(Func<Student, bool> func)
        {
            return _studentDao.GetStudents(func);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDemo.Core.Dao;
using ApiDemo.Core.Entities;

namespace ApiDemo.Core.AppService
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentDao _studentDao;

        public StudentAppService(IStudentDao studentDao)
        {
            _studentDao = studentDao;
        }

        public StudentAppService()
        {
            // TODO: Complete member initialization
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

        public bool Delete(int id)
        {
            return _studentDao.Delete(id);
        }
    }
}

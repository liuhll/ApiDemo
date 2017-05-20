using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDemo.Core.Entities
{
    public class Student
    {
        public Student()
        {
        }

        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Column(Order = 2)]
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
using System.Data.Entity;
using ApiDemo.Core.Entities;

namespace ApiDemo.Core.EntityFramework
{
    public class DemoContext : DbContext
    {
   
        public DemoContext()
            : base("Default")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<AppCode> AppCodes { get; set; }


    }
}
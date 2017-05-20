using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Core.Entities
{
    public class AppCode
    {
        [Key]
        public string AppId { get; set; }

        [Required]
        public string AppKey { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}
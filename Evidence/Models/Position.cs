using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evidence.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, Int32.MaxValue)]
        public int Cost { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

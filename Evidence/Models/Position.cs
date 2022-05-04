using System.Collections.Generic;

namespace Evidence.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

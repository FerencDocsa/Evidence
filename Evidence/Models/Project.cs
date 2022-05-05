using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evidence.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
    }
}

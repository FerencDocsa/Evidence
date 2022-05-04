using System.Collections.Generic;

namespace Evidence.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
    }
}

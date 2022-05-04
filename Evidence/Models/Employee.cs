using System.Collections.Generic;


namespace Evidence.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public virtual Position PositionNavigation { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
    }
}

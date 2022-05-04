using System;
using System.Collections.Generic;

namespace Evidence.Models
{
    public partial class Action
    {
        public int Id { get; set; }
        public int Employee { get; set; }
        public int Project { get; set; }
        public int Cost { get; set; }
        public DateTime ActionDate { get; set; }
        public int SpentTime { get; set; }

        public virtual Employee EmployeeNavigation { get; set; }
        public virtual Project ProjectNavigation { get; set; }
    }
}

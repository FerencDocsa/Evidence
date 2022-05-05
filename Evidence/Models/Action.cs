using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evidence.Models
{
    public class Action
    {
        public int Id { get; set; }

        [Display(Name = "Zaměstnanec")]
        public int Employee { get; set; }
        [Display(Name = "Projekt")]
        public int Project { get; set; }

        [Display(Name = "Náklady (Kč)")]
        public int Cost { get; set; }

        [Display(Name = "Datum Činnosti")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ActionDate { get; set; }

        [Display(Name = "Odpracováno hodin")]
        public int SpentTime { get; set; }

        public virtual Employee EmployeeNavigation { get; set; }
        public virtual Project ProjectNavigation { get; set; }
    }
}

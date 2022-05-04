using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Evidence.Models.ViewModels
{
    public class ActionAddViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Zaměstnanec")]
        public int SelectedEmployee { get; set; }
        public List<Employee> Employees { get; set; }


        [Display(Name = "Projekt")]
        public int SelectedProject { get; set; }
        public List<Project> Projects { get; set; }

        [Display(Name = "Náklad")]
        public int Cost { get; set; }

        [Display(Name = "Datum Činnosti")]
        public DateTime ActionDate { get; set; }

        [Display(Name = "Odpracováno hodin")]
        [Range(1, 8, ErrorMessage = "Minimální povolený počet je 1 hodina a maximální je 8")]
        public int SpentTime { get; set; }
    }
}

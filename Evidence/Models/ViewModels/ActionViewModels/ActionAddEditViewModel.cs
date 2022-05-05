using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Evidence.Models.ViewModels
{
    public class ActionAddEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Zaměstnanec")]
        [Required(ErrorMessage = "Musí se vybrat zaměstnanec")]
        public int SelectedEmployee { get; set; }
        public List<Employee> Employees { get; set; }

        [Display(Name = "Projekt")]
        [Required(ErrorMessage = "Musí se vybrat projekt")]
        public int SelectedProject { get; set; }
        public List<Project> Projects { get; set; }

        [Display(Name = "Náklady (Kč)")]
        public int Cost { get; set; }

        [Display(Name = "Datum Činnosti")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ActionDate { get; set; }

        [Display(Name = "Odpracováno hodin")]
        [Range(1, 8, ErrorMessage = "Minimální povolený počet je 1 hodina a maximální je 8")]
        public int SpentTime { get; set; }
    }
}

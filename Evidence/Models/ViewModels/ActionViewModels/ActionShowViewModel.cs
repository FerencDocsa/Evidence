using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evidence.Models.ViewModels
{
    public class ActionShowViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Zaměstnanec")]
        public string Employee { get; set; }
        [Display(Name = "Projekt")]
        public string Project { get; set; }
        public int ProjectId { get; set; }
        [Display(Name = "Náklad")]
        public int Cost { get; set; }
        [Display(Name = "Datum Činnosti")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ActionDate { get; set; }
        [Display(Name = "Odpracováno hodin")]
        public int SpentTime { get; set; }
    }
}

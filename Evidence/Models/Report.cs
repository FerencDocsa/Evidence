using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidence.Models
{
    public class Report
    {
        [Display(Name = "Projekt")]
        public string ProjectName { get; set; }

        [Display(Name = "Nakladý (Kč)")]
        public int Costs { get; set; }

        [Display(Name = "Odpracovano")]
        public int SpentTime { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //public DateTime ActionDate { get; set; }
    }
}

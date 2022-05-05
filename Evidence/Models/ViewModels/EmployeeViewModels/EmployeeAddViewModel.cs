using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Evidence.Models.ViewModels
{
    public class EmployeeAddViewModel
    {
        [Required]
        [Display(Name = "Jmeno")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Pozice")]
        public int SelectedPosition { get; set; }
        public List<Position> Positions { get; set; }
    }
}

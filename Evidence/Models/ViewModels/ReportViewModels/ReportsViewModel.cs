using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evidence.Models.ViewModels
{
    public class ReportsViewModel
    {
        public ReportsViewModel()
        {
            Reports = new List<Report>();
        }

        public List<Report> Reports { get; set; }
    }
}

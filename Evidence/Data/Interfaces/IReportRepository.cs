using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Models.ViewModels;

namespace Evidence.Data.Interfaces
{
    public interface IReportRepository
    {
        public Task<ReportsViewModel> GetReport();
        public Task<ReportsViewModel> GetReportByDate(DateTime? dateFrom, DateTime? dateTo);
    }
}

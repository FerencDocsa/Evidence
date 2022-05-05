using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evidence.Data.Interfaces;
using Evidence.Models;
using Evidence.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Action = Evidence.Models.Action;

namespace Evidence.Data
{
    public class ReportRepository : IReportRepository
    {
        private readonly EvidenceContext _ctx;

        public ReportRepository(EvidenceContext ctx)
        {
            _ctx = ctx;
        }

        private async Task<ReportsViewModel> GetReports(DateTime? dateFrom, DateTime? dateTo)
        {
            var vm = new ReportsViewModel();
            var projects = await _ctx.Projects.ToListAsync();

            foreach (var project in projects)
            {
                IQueryable<Action> actions;

                if (dateFrom != null && dateTo != null)
                {
                    actions = _ctx.Actions.Where(c => c.Project == project.Id && c.ActionDate >= dateFrom && c.ActionDate <= dateTo);
                }
                else
                {
                    actions = _ctx.Actions.Where(c => c.Project == project.Id);
                }

                var costs = actions.Sum(c => c.Cost);
                var spentTime = actions.Sum(c => c.SpentTime);

                vm.Reports.Add(new Report
                {
                    ProjectName = project.Name,
                    Costs = costs,
                    SpentTime = spentTime
                });
            }

            return vm;
        }

        public async Task<ReportsViewModel> GetReport()
        {
            return await GetReports(null, null);
        }


        public async Task<ReportsViewModel> GetReportByDate(DateTime? dateFrom, DateTime? dateTo)
        {
            return await GetReports(dateFrom, dateTo);

        }
    }
}

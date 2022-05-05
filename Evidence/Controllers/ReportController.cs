using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Data.Interfaces;
using Evidence.Models;
using Evidence.Models.ViewModels;

namespace Evidence.Controllers
{
    public class ReportController : Controller
    {
        private readonly EvidenceContext _ctx;
        private readonly IReportRepository _reportRepository;

        public ReportController(EvidenceContext ctx, IReportRepository reportRepository)
        {
            _ctx = ctx;
            _reportRepository = reportRepository;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            var result = await _reportRepository.GetReport();
            return View(result);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind] DateTime? dateFrom, DateTime? dateTo)
        {
            ReportsViewModel vm;

            if (dateFrom == null || dateTo == null)
                vm = await _reportRepository.GetReport();

            vm = await _reportRepository.GetReportByDate(dateFrom, dateTo);

            return View(vm);
        }
    }
}

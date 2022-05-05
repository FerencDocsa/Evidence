using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Data;
using Evidence.Data.Interfaces;
using Evidence.Models;
using Evidence.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Evidence.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EvidenceContext _ctx;
        private readonly IEmpolyeeRepository _repository;
        private readonly IPositionRepository _positionRepository;

        public EmployeeController(EvidenceContext ctx, IEmpolyeeRepository employeeRepository, IPositionRepository positionRepository)
        {
            _ctx = ctx;
            _repository = employeeRepository;
            _positionRepository = positionRepository;
        }

        // GET: ZamestnanceController
        public ActionResult Index()
        {
            return View(_repository.GetEmployees());
        }
        
        // GET: ZamestnanceController/Create
        public async Task<ActionResult> Create()
        {
            var positions = await _positionRepository.GetPositions();
            var vm = new EmployeeAddViewModel { Positions = positions.ToList() };

            return View(vm);
        }

        // POST: ZamestnanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeAddViewModel vm)
        {
            if(ModelState.IsValid){
                _repository.CreateEmployee(vm);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}

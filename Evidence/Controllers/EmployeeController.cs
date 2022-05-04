using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Data;
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

        public EmployeeController(EvidenceContext ctx, IEmpolyeeRepository repository)
        {
            _ctx = ctx;
            _repository = repository;
        }

        // GET: ZamestnanceController
        public ActionResult Index()
        {
            return View(_repository.GetEmployees());
        }

        //// GET: ZamestnanceController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ZamestnanceController/Create
        public ActionResult Create()
        {
            var emp = new AddNewEmployeeViewModel();
            emp.Positions = _ctx.Positions.ToList();
            return View(emp);
        }

        // POST: ZamestnanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddNewEmployeeViewModel vm)
        {
            if(ModelState.IsValid){
                _repository.CreateEmployee(vm);
                return RedirectToAction("Index");
            }
            return View();
        }

        //// GET: ZamestnanceController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ZamestnanceController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ZamestnanceController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ZamestnanceController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

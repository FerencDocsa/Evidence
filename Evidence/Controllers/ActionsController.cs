#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evidence.Models;
using Evidence.Models.ViewModels;
using Action = Evidence.Models.Action;

namespace Evidence.Controllers
{
    public class ActionsController : Controller
    {
        private readonly EvidenceContext _ctx;
        private readonly IActionRepository _actionRepository;

        public ActionsController(EvidenceContext ctx, IActionRepository actionRepository)
        {
            _ctx = ctx;
            _actionRepository = actionRepository;
        }

        // GET: Actions ++
        public async Task<IActionResult> Index()
        {
            return View(await _actionRepository.GetActions());
        }

        // GET: Actions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var action = await _actionRepository.GetAction((int)id);

            if (action == null)
            {
                return NotFound();
            }

            return View(action);
        }

        // GET: Actions/Create
        // V pripade s kontrolovanim hodin bylo by vhodnejsi napsat JavaScript 
        public IActionResult Create(string? message)
        {
            var vm = new ActionAddEditViewModel {Employees = _ctx.Employees.ToList(), Projects = _ctx.Projects.ToList(), ActionDate = DateTime.Today };

            if (!string.IsNullOrEmpty(message))
                ViewData["message"] = message;

            return View(vm);
        }

        //POST: Actions/Create/Model
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind]ActionAddEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (await _actionRepository.AddAction(vm))
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Create", new {message = "Překročen povolený počet hodin pro tento den" });
            }

            return RedirectToAction("Index");
        }

        // GET: Actions/Edit/5
        public async Task<IActionResult> Edit(int? id, string? message)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(message))
                ViewData["message"] = message;

            var getAction = await _actionRepository.GetAction((int)id);

            var vm = new ActionAddEditViewModel 
            {   
                Employees = _ctx.Employees.ToList(),
                Projects = _ctx.Projects.ToList(),
                Cost = getAction.Cost,
                SpentTime = getAction.SpentTime,
                SelectedEmployee = getAction.EmployeeNavigation.Id,
                SelectedProject = getAction.ProjectNavigation.Id,
                ActionDate = getAction.ActionDate
            };

            return View(vm);
        }

        // POST: Actions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind]ActionAddEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (await _actionRepository.EditAction(vm))
                {
                    return RedirectToAction("Edit", new {vm.Id });
                }

                return RedirectToAction("Edit", new {vm.Id, message = "Překročen povolený počet hodin pro tento den" });
            }
            return RedirectToAction("Index");
        }

        // GET: Actions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var action = await _actionRepository.GetAction((int)id);

            if (action == null)
            {
                return NotFound();
            }

            return View(action);
        }

        // POST: Actions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _actionRepository.DeleteAction(id);
            return RedirectToAction("Index");
        }

        private bool ActionExists(int id)
        {
            return _ctx.Actions.Any(e => e.Id == id);
        }
    }
}

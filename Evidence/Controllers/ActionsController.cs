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

        // GET: Actions
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

            var action = await _ctx.Actions
                .Include(a => a.EmployeeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (action == null)
            {
                return NotFound();
            }

            return View(action);
        }

        // GET: Actions/Create
        public IActionResult Create()
        {
            var vm = new ActionAddViewModel();
            vm.Employees = _ctx.Employees.ToList();
            vm.Projects = _ctx.Projects.ToList();
            vm.ActionDate = DateTime.Today;

            return View(vm);
        }

        // POST: Actions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind]ActionAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var employeePositionCost = _ctx.Employees.Include(c => c.PositionNavigation).FirstOrDefault(x => x.Id == vm.SelectedEmployee).PositionNavigation.Cost;

                var newAction = new Action
                {
                    Employee = vm.SelectedEmployee,
                    ActionDate = vm.ActionDate,
                    Cost = employeePositionCost * vm.SpentTime,
                    Project = vm.SelectedProject,
                    SpentTime = vm.SpentTime
                };

                
                _ctx.Add(newAction);
                await _ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Employee"] = new SelectList(_ctx.Employees, "Id", "Name", vm.Employee);
            return View(vm);
        }

        // GET: Actions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var action = await _ctx.Actions.FindAsync(id);
            if (action == null)
            {
                return NotFound();
            }
            ViewData["Employee"] = new SelectList(_ctx.Employees, "Id", "Name", action.Employee);
            return View(action);
        }

        // POST: Actions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Employee,Project,Cost,ActionDate,SpentTime")] Action action)
        {
            if (id != action.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ctx.Update(action);
                    await _ctx.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActionExists(action.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee"] = new SelectList(_ctx.Employees, "Id", "Name", action.Employee);
            return View(action);
        }

        // GET: Actions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var action = await _ctx.Actions
                .Include(a => a.EmployeeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var action = await _ctx.Actions.FindAsync(id);
            _ctx.Actions.Remove(action);
            await _ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActionExists(int id)
        {
            return _ctx.Actions.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Models;
using Evidence.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Action = Evidence.Models.Action;

namespace Evidence.Data.Interfaces
{
    public class ActionRepository : IActionRepository
    {
        private readonly EvidenceContext _ctx;

        public ActionRepository(EvidenceContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<Action>> GetActions()
        {
            var result = await _ctx.Actions
                .Include(c => c.EmployeeNavigation)
                .Include(c => c.ProjectNavigation).ToListAsync();

            return result;
        }

        public async Task<Action> GetAction(int id)
        {
            var result = await _ctx.Actions
                .Include(a => a.EmployeeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            return result;
        }

        public async Task<bool> AddAction(ActionAddEditViewModel vm)
        {
            if (IsHourOverdraft(vm))
                return false;
            
            var positionCost = _ctx.Employees.Include(c => c.PositionNavigation).FirstOrDefault(x => x.Id == vm.SelectedEmployee).PositionNavigation.Cost;
            
            var newAction = new Action
            {
                Employee = vm.SelectedEmployee,
                ActionDate = vm.ActionDate,
                Cost = positionCost * vm.SpentTime,
                Project = vm.SelectedProject,
                SpentTime = vm.SpentTime
            };

            _ctx.Add(newAction);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditAction(ActionAddEditViewModel vm)
        {
            if (IsHourOverdraft(vm))
                return false;

            var positionCost = _ctx.Employees.Include(c => c.PositionNavigation).FirstOrDefault(x => x.Id == vm.SelectedEmployee).PositionNavigation.Cost;

            var actionToUpdate = await GetAction(vm.Id);
            actionToUpdate.Employee = vm.SelectedEmployee;
            actionToUpdate.Project = vm.SelectedProject;
            actionToUpdate.ActionDate = vm.ActionDate;
            actionToUpdate.SpentTime = vm.SpentTime;
            actionToUpdate.Cost = positionCost * vm.SpentTime;

            _ctx.Update(actionToUpdate);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAction(int id)
        {
            var action = await _ctx.Actions.FindAsync(id);
            _ctx.Actions.Remove(action);
            await _ctx.SaveChangesAsync();
        }

        private bool IsHourOverdraft(ActionAddEditViewModel vm)
        {
            var hoursSpent = _ctx.Actions
                .Include(c => c.EmployeeNavigation)
                .Where(x => x.ActionDate == vm.ActionDate
                            && x.EmployeeNavigation.Id == vm.SelectedEmployee)
                .Sum(c => c.SpentTime);

            bool isHourOverdraft = hoursSpent + vm.SpentTime > 8;

            return isHourOverdraft;
        }
    }
}

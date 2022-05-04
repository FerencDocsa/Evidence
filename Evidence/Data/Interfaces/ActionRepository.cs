using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Models;
using Evidence.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Evidence.Data.Interfaces
{
    public class ActionRepository : IActionRepository
    {
        private readonly EvidenceContext _ctx;

        public ActionRepository(EvidenceContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<ActionShowViewModel>> GetActions()
        {
            var actions = _ctx.Actions.Select(c =>
                new ActionShowViewModel
                {
                    Id = c.Id,
                    Employee = c.EmployeeNavigation.Name,
                    Cost = c.Cost,
                    ActionDate = c.ActionDate,
                    Project = c.ProjectNavigation.Name,
                    SpentTime = c.SpentTime
                });

            return await actions.ToListAsync();
        }
    }
}

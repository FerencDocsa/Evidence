using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Models.ViewModels;
using Action = Evidence.Models.Action;

namespace Evidence.Data.Interfaces
{
    public interface IActionRepository
    {
        public Task<List<Action>> GetActions();
        public Task<Action> GetAction(int id);
        public Task<bool> AddAction(ActionAddEditViewModel vm);
        public Task<bool> EditAction(ActionAddEditViewModel vm);
    }
}

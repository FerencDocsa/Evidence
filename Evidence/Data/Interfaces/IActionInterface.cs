using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Models.ViewModels;

namespace Evidence.Data.Interfaces
{
    public interface IActionRepository
    {
        public Task<List<ActionShowViewModel>> GetActions();
    }
}

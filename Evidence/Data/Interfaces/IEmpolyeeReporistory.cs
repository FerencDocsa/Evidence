using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Models;
using Evidence.Models.ViewModels;

namespace Evidence.Data
{
    public interface IEmpolyeeRepository
    {
        public IEnumerable<Employee> GetEmployees();
        public void CreateEmployee(AddNewEmployeeViewModel vm);
    }
}

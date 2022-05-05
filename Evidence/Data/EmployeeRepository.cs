using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Models;
using Evidence.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Evidence.Data
{
    public class EmployeeRepository : IEmpolyeeRepository
    {
        private readonly EvidenceContext _ctx;

        public EmployeeRepository(EvidenceContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _ctx.Employees.Include(c => c.PositionNavigation);
        }

        public void CreateEmployee(EmployeeAddViewModel vm)
        {
            var newEmployee = new Employee
            {
                Name = vm.Name,
                Position = vm.SelectedPosition
            };

            _ctx.Employees.Add(newEmployee);
            _ctx.SaveChanges();
        }
    }
}

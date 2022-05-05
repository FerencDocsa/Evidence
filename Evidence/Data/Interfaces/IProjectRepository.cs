using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Models;

namespace Evidence.Data
{
    public interface IProjectRepository
    {
        public Task<Project> GetProject(int id);
        public Task<IEnumerable<Project>> GetProjects();
        public Task AddProject(Project project);
        public Task EditProject(int id, Project project);
        public Task DeleteProject(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Models;
using Microsoft.EntityFrameworkCore;

namespace Evidence.Data
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly EvidenceContext _ctx;

        public ProjectRepository(EvidenceContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Project> GetProject(int id)
        {
            return await _ctx.Projects.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await _ctx.Projects.ToListAsync();
        }

        public async Task AddProject(Project project)
        {
            _ctx.Projects.Add(project);
            await _ctx.SaveChangesAsync();
        }

        public async Task EditProject(int id, Project project)
        {
            var projectToEdit = await GetProject(id);
            projectToEdit.Name = project.Name;
            _ctx.Projects.Update(projectToEdit);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var projectToDelete = await GetProject(id);
            _ctx.Projects.Remove(projectToDelete);
            await _ctx.SaveChangesAsync();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Data;
using Evidence.Models;
using Microsoft.EntityFrameworkCore;

namespace Evidence.Controllers
{
    public class ProjectController : Controller
    {
        private readonly EvidenceContext _ctx;
        private readonly IProjectRepository _projectRepository;

        public ProjectController(EvidenceContext ctx, IProjectRepository projectRepository)
        {
            _ctx = ctx;
            _projectRepository = projectRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Project> projects = await _projectRepository.GetProjects();
            return View(projects);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            if(project == null)
                return RedirectToAction("Index");

            await _projectRepository.AddProject(project);

            return RedirectToAction("Index");
        }
    }
}

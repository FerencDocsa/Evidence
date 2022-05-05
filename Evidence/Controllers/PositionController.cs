using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Data;
using Evidence.Data.Interfaces;
using Evidence.Models;

namespace Evidence.Controllers
{
    public class PositionController : Controller
    {
        private readonly EvidenceContext _ctx;
        private readonly IPositionRepository _positionRepository;

        public PositionController(EvidenceContext ctx, IPositionRepository positionRepository)
        {
            _ctx = ctx;
            _positionRepository = positionRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Position> positions = await _positionRepository.GetPositions();
            return View(positions);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(Position position)
        {
            if (position == null)
                return RedirectToAction("Index");

            await _positionRepository.AddPosition(position);

            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Data.Interfaces;
using Evidence.Models;
using Microsoft.EntityFrameworkCore;

namespace Evidence.Data
{
    public class PositionRepository : IPositionRepository
    {
        private readonly EvidenceContext _ctx;

        public PositionRepository(EvidenceContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Position> GetPosition(int id)
        {
            return await _ctx.Positions.FindAsync(id);
        }

        public async Task<IEnumerable<Position>> GetPositions()
        {
            return await _ctx.Positions.ToListAsync();
        }

        public async Task AddPosition(Position position)
        {
            _ctx.Positions.Add(position);
            await _ctx.SaveChangesAsync();
        }

        public async Task EditPosition(int id, Position position)
        {
            var positionToEdit = await GetPosition(id);
            positionToEdit.Name = position.Name;
            positionToEdit.Cost = position.Cost;
            _ctx.Positions.Update(positionToEdit);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeletePosition(int id)
        {
            var positionToDelete = await GetPosition(id);
            _ctx.Positions.Remove(positionToDelete);
            await _ctx.SaveChangesAsync();
        }
    }
}

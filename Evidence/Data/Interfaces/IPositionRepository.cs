using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evidence.Models;

namespace Evidence.Data.Interfaces
{
    public interface IPositionRepository
    {
        public Task<Position> GetPosition(int id);
        public Task<IEnumerable<Position>> GetPositions();
        public Task AddPosition(Position position);
        public Task EditPosition(int id, Position position);
        public Task DeletePosition(int id);
    }
}

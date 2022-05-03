using Microsoft.EntityFrameworkCore;

namespace Evidence.Data
{
    public class EvidenceDbContext : DbContext
    {
        public EvidenceDbContext(DbContextOptions<EvidenceDbContext> options) : base(options) { }
    }
}

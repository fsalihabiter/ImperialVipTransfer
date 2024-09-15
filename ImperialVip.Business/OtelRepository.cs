

using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;

namespace ImperialVip.Business
{
    public class OtelRepository : Repository<Otel>, IOtelRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }

        public OtelRepository(ImperialDatabaseContext context) : base(context)
        {
        }
    }
}

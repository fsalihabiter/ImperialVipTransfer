

using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;

namespace ImperialVip.Business
{
    public class RezervasyonKisiRepository : Repository<RezervasyonKisi>, IRezervasyonKisiRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }

        public RezervasyonKisiRepository(ImperialDatabaseContext context) : base(context)
        {
        }
    }
}

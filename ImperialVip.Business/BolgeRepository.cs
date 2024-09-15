
using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;

namespace ImperialVip.Business
{
    public class BolgeRepository : Repository<Bolge>, IBolgeRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }

        public BolgeRepository(ImperialDatabaseContext context) : base(context)
        {
        }
    }
}

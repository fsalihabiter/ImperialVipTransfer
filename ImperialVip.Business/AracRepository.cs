using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;

namespace ImperialVip.Business
{
    public class AracRepository : Repository<Arac>, IAracRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }

        public AracRepository(ImperialDatabaseContext context) : base(context)
        {
            
        }
    }
}

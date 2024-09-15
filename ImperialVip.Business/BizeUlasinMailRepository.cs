
using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;

namespace ImperialVip.Business
{
    public class BizeUlasinMailRepository : Repository<BizUlasinMail>, IBizeUlasinMailRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }
        public BizeUlasinMailRepository(ImperialDatabaseContext context) : base(context)
        {
        }
    }
}


using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;

namespace ImperialVip.Business
{
    public class KategoriRepository : Repository<IcerikKategori>, IKategoriRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }

        public KategoriRepository(ImperialDatabaseContext context) : base(context)
        {
        }
    }
}

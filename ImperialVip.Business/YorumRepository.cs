
using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ImperialVip.Business
{
    public class YorumRepository : Repository<Yorum>, IYorumRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }

        public YorumRepository(ImperialDatabaseContext context) : base(context)
        {
        }

        public void YorumuOnayla(int yorumId)
        {
            Yorum yorum = null;
            yorum.OnayDurumu = true;
            Context.Yorumlar.AddOrUpdate(yorum);
        }

    }
}

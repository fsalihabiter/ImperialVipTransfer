using ImperialVip.Business.Interfaces;
using ImperialVip.Common.Enums;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;
using ImperialVip.DataAccess.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ImperialVip.Business
{
    public class IcerikRepository : Repository<Icerik>, IIcerikRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }

        public IcerikRepository(ImperialDatabaseContext context) : base(context)
        {
        }

        public IEnumerable<IcerikViewModel> GetSliders()
        {
            var sliders = (from i in Context.Icerikler.Include("IcerikKategoriler")
                           join k in Context.IcerikKategoriler on i.IcerikKategoriId equals k.Id
                           join d in Context.Diller on i.DilId equals d.Id
                           where i.IcerikKategoriId == 1
                           select new IcerikViewModel
                           {
                               Id = i.Id,
                               DilId = i.DilId,
                               DilAdi = d.DilAdi,
                               IcerikKategoriId = i.IcerikKategoriId,
                               KategoriAdi = k.KategoriAdi,
                               IcerikBaslik = i.IcerikBaslik,
                               IcerikDetay = i.IcerikDetay,
                               ResimUrl = i.ResimUrl
                           }).ToList();
            return sliders;
        }
        public IEnumerable<Icerik> GetAboutUs()
        {
            var sliders = Context.Icerikler.Where(x => x.IcerikKategoriId == 3).ToList();
            return sliders;
        }


    }
}


using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;
using ImperialVip.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ImperialVip.Business
{
    public class BolgeAracFiyatRepository : Repository<BolgeyeGoreAracFiyat>, IBolgeAracFiyatRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }

        public BolgeAracFiyatRepository(ImperialDatabaseContext context) : base(context)
        {
        }

        public IEnumerable<BolgeDetayViewModel> BolgeleriGetir()
        {
            List<BolgeDetayViewModel> bolgeler = new List<BolgeDetayViewModel>();

            bolgeler = (from baf in Context.BolgeyeGoreAracFiyatlar
                        join b in Context.Bolgeler on baf.BolgeId equals b.Id
                        join a in Context.Araclar on baf.AracId equals a.Id
                        select new BolgeDetayViewModel
                        {
                            Id = baf.Id,
                            BolgeId = baf.BolgeId,
                            BolgeAdi = b.BolgeAdi,
                            BolgeDetay = b.BolgeDetay,
                            AracId = baf.AracId,
                            AracAdi = a.AracAdi,
                            Fiyat = baf.Fiyat,
                            AlisNoktasiMi = b.AlisNoktasiMi,
                            ResimUrl = b.ResimUrl
                        }).ToList();

            return bolgeler;
        }

        public IEnumerable<BolgeDetayViewModel> BolgeleriGetir(Expression<Func<BolgeyeGoreAracFiyat, bool>> predicate)
        {
            List<BolgeDetayViewModel> bolgeler = new List<BolgeDetayViewModel>();

            bolgeler = Context.BolgeyeGoreAracFiyatlar
                        .Where(predicate)
                        .GroupBy(b => b.BolgeId)
                        .Select(b => new BolgeDetayViewModel
                        {
                            Id = b.Select(a => a.Id).FirstOrDefault(),
                            BolgeId = b.Key,
                            BolgeAdi = b.Select(a => a.Bolge.BolgeAdi).FirstOrDefault(),
                            BolgeDetay = b.Select(a => a.Bolge.BolgeDetay).FirstOrDefault(),
                            AracId = b.Select(a => a.Arac.Id).FirstOrDefault(),
                            AracAdi = b.Select(a => a.Arac.AracAdi).FirstOrDefault(),
                            Fiyat = b.Min(f => f.Fiyat),
                            AlisNoktasiMi = b.Select(a => a.Bolge.AlisNoktasiMi).FirstOrDefault(),
                            ResimUrl = b.Select(a => a.Bolge.ResimUrl).FirstOrDefault()
                        }).ToList();

            return bolgeler;
        }
    }
}

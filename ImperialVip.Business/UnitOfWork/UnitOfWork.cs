using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.Business.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImperialDatabaseContext _context;

        public IAracRepository Araclar { get; private set; }

        public IBizeUlasinMailRepository BizeUlasinMailler { get; private set; }

        public IBolgeRepository Bolgeler { get; private set; }

        public IBolgeAracFiyatRepository BolgeAracFiyatlari  { get; private set; }

        public IIcerikRepository Icerikler  { get; private set; }

        public IKategoriRepository Kategoriler  { get; private set; }

        public IKullaniciRepository Kullanicilar { get; private set; }

        public IOtelRepository Oteller  { get; private set; }

        public IRezervasyonKisiRepository GelenKisiler  { get; private set; }

        public IRezervasyonRepository Rezervasyonlar  { get; private set; }

        public IYorumRepository Yorumlar  { get; private set; }

        public UnitOfWork(ImperialDatabaseContext context)
        {
            _context = context;
            Araclar = new AracRepository(_context);
            BizeUlasinMailler = new BizeUlasinMailRepository(_context);
            Bolgeler = new BolgeRepository(_context);
            BolgeAracFiyatlari = new BolgeAracFiyatRepository(_context);
            Icerikler = new  IcerikRepository(_context);
            Kategoriler = new KategoriRepository(_context);
            Kullanicilar = new KullaniciRepository(_context);
            Oteller = new OtelRepository(_context);
            GelenKisiler = new RezervasyonKisiRepository(_context);
            Rezervasyonlar = new RezervasyonRepository(_context);
            Yorumlar = new YorumRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using ImperialVip.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.Business.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAracRepository Araclar { get; }
        IBizeUlasinMailRepository BizeUlasinMailler { get; }
        IBolgeRepository Bolgeler { get; }
        IBolgeAracFiyatRepository BolgeAracFiyatlari { get; }
        IIcerikRepository Icerikler { get; }
        IKategoriRepository Kategoriler { get; }
        IKullaniciRepository Kullanicilar { get; }
        IOtelRepository Oteller { get; }
        IRezervasyonKisiRepository GelenKisiler { get; }
        IRezervasyonRepository Rezervasyonlar { get; }
        IYorumRepository Yorumlar { get; }

        int Complete();
    }
}

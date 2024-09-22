
using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;
using ImperialVip.DataAccess.ViewModels;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;

namespace ImperialVip.Business
{
    public class RezervasyonRepository : Repository<Rezervasyon>, IRezervasyonRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }

        public RezervasyonRepository(ImperialDatabaseContext context) : base(context)
        {
        }

        public List<RezervasyonModel> RezervasyonGetir()
        {
            List<RezervasyonModel> rezervler = new List<RezervasyonModel>();

            rezervler = (from r in Context.Rezervasyonlar
                       join a in Context.Bolgeler on r.AlisNoktasiId equals a.Id
                       join v in Context.Bolgeler on r.VarisNoktasiId equals v.Id
                       join ar in Context.Araclar on r.AracId equals ar.Id
                       select new RezervasyonModel
                       {
                           Id = r.Id,
                           AlisNoktasiId = r.AracId,
                           AlisNoktasiAdi = a.BolgeAdi,
                           VarisNoktasiId = r.VarisNoktasiId,
                           VarisNoktasiAdi = v.BolgeAdi,
                           AracId = ar.Id,
                           AracAdi = ar.AracAdi,
                           KisiSayisi = r.YetiskinSayisi + " Yetişkin - " + r.CocukSayisi + " Çocuk",
                           OtelAdi = r.OtelAdi,
                           AdSoyad = r.AdSoyad,
                           Telefon = r.Telefon,
                           Email = r.Email,
                           CocukKoltuguSayisi = r.CocukKoltuguSayisi,
                           GelisTarihi = r.GelisTarihi,
                           GelisUcusNumarasi = r.GelisUcusNumarasi,
                           DonusTarihi = r.DonusTarihi,
                           DonusUcusNumarasi = r.DonusUcusNumarasi,
                           DilKodu = r.DilKodu,
                           Fiyat = r.Fiyat,
                           OzelNot = r.OzelNot,
                           RezervasyonOnay = r.RezervasyonOnay,
                           KayitTarihi = r.KayitTarihi
                       }).ToList();

            return rezervler;
        }

        public RezervasyonModel RezervasyonGetirById(int id)
        {
            RezervasyonModel bolgeler = new RezervasyonModel();

            bolgeler = (from r in Context.Rezervasyonlar
                        join a in Context.Bolgeler on r.AlisNoktasiId equals a.Id
                        join v in Context.Bolgeler on r.VarisNoktasiId equals v.Id
                        join ar in Context.Araclar on r.AracId equals ar.Id
                        where r.Id == id
                        select new RezervasyonModel
                        {
                            Id = r.Id,
                            AlisNoktasiId = r.AracId,
                            AlisNoktasiAdi = a.BolgeAdi,
                            VarisNoktasiId = r.VarisNoktasiId,
                            VarisNoktasiAdi = v.BolgeAdi,
                            AracId = ar.Id,
                            AracAdi = ar.AracAdi,
                            KisiSayisi = r.YetiskinSayisi + " Yetişkin - " + r.CocukSayisi + " Çocuk",
                            OtelAdi = r.OtelAdi,
                            AdSoyad = r.AdSoyad,
                            Telefon = r.Telefon,
                            Email = r.Email,
                            CocukKoltuguSayisi = r.CocukKoltuguSayisi,
                            GelisTarihi = r.GelisTarihi,
                            GelisUcusNumarasi = r.GelisUcusNumarasi,
                            DonusTarihi = r.DonusTarihi,
                            DonusUcusNumarasi = r.DonusUcusNumarasi,
                            DilKodu = r.DilKodu,
                            Fiyat = r.Fiyat,
                            OzelNot = r.OzelNot,
                            RezervasyonOnay = r.RezervasyonOnay,
                            KayitTarihi = r.KayitTarihi
                        }).FirstOrDefault();

            return bolgeler;
        }
    }
}

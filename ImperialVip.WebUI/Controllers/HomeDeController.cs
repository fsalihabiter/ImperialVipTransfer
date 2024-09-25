using ImperialVip.Business;
using ImperialVip.Business.UnitOfWork;
using ImperialVip.Common;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.ViewModels;
using ImperialVip.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImperialVip.WebUI.Controllers
{
    [Route("de")]
    public class HomeDeController : Controller
    {
        [Route("de/Home")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logo()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Icerik logo = unitOfWork.Icerikler.Find(l => l.IcerikKategoriId == 8 && l.DilId == 3);
                return PartialView("_Logo", logo);
            }
        }

        public ActionResult Footer()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Icerik footer = unitOfWork.Icerikler.Find(l => l.IcerikKategoriId == 7 && l.DilId == 3);
                ViewBag.iletisim = unitOfWork.Icerikler.FindAll(i => i.IcerikKategoriId == 5 && i.DilId == 3).ToList();
                return PartialView("_Footer", footer);
            }
        }

        public ActionResult Regions()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<BolgeDetayViewModel> bolgeler = unitOfWork.BolgeAracFiyatlari.BolgeleriGetir().OrderBy(b => b.BolgeAdi).Take(6).ToList();

                return PartialView("_Regions", bolgeler);
            }
        }

        public ActionResult OurServices()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Icerik> hizmetler = unitOfWork.Icerikler.FindAll(s => s.IcerikKategoriId == 2 && s.DilId == 3).ToList();
                ViewBag.kategori = unitOfWork.Kategoriler.Find(k => k.Id == 2);
                return PartialView("_OurServices", hizmetler);
            }
        }

        public ActionResult AboutUs()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Icerik> hakkimizda = unitOfWork.Icerikler.FindAll(s => s.IcerikKategoriId == 3 && s.DilId == 3).ToList();
                ViewBag.kategori = unitOfWork.Kategoriler.Find(k => k.Id == 3);
                return PartialView("_AboutUs", hakkimizda);
            }
        }

        public ActionResult WhyUs()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Icerik> nedenBiz = unitOfWork.Icerikler.FindAll(s => s.IcerikKategoriId == 4 && s.DilId == 3).ToList();
                ViewBag.kategori = unitOfWork.Kategoriler.Find(k => k.Id == 4);
                return PartialView("_WhyUs", nedenBiz);
            }
        }

        [HttpGet]
        [Route("de/ContactUs")]
        public ActionResult ContactUs()
        {
            BizeUlasinDTO bizeUlasinModel = new BizeUlasinDTO();
            return PartialView("_ContactUs", bizeUlasinModel);
        }

        [HttpPost]
        [Route("de/ContactUs")]
        public JsonResult ContactUs(BizeUlasinDTO bizeUlasinModel)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                string body = "<div style='display: flex; flex-direction: column; align-items: stretch; justify-content: stretch; font-family:arial,helvetica,sans-serif;'>" +
                                    "<h3 style='background-color: #19335c; color: #f5b754; padding:30px; text-align: center; font-size: 24px; margin: 0;'>Imperial VIP Transfer</h3>" +
                                    "<h6 style='background-color: #19335c; color: #f5b754; padding-bottom:30px; text-align: center; font-size: 15px; font-weight: 300; margin: 0;'>Kontaktieren Sie uns Nachrichtendetails</h3>" +
                                    "<table style='padding: 20px;'>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Vorname Nachname : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{bizeUlasinModel.AdSoyad}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Telefonnummer : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{bizeUlasinModel.Telefon}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>E-Mail-Adresse : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{bizeUlasinModel.Email}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Nachricht : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{bizeUlasinModel.Mesaj}</td>" +
                                        "</tr>" +
                                    "</table>" +
                                "</div>";

                var mailGonderildiMi = MailHelper.SendBizeUlasinMail(body);

                if (mailGonderildiMi)
                {
                    BizUlasinMail mail = new BizUlasinMail
                    {
                        AdSoyad = bizeUlasinModel.AdSoyad,
                        Telefon = bizeUlasinModel.Telefon,
                        Email = bizeUlasinModel.Email,
                        Mesaj = bizeUlasinModel.Mesaj,
                        GonderimTarihi = DateTime.Now
                    };

                    unitOfWork.BizeUlasinMailler.Insert(mail);
                    unitOfWork.Complete();

                    return Json(new { success = true, message = "Ihre Nachricht wurde erfolgreich zugestellt." }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false, message = "Ihre Nachricht konnte aufgrund eines Problems nicht zugestellt werden." }, JsonRequestBehavior.AllowGet);

            }
        }

        [Route("de/Comments")]
        public ActionResult Comments()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Yorum> yorumlar = unitOfWork.Yorumlar.GetAll().Where(x => x.OnayDurumu).OrderByDescending(y => y.YorumTarihi).Take(5).ToList();
                return PartialView("_Comments", yorumlar);
            }
        }

        [HttpPost]
        [Route("de/Comments")]
        public JsonResult Comments(YorumViewModel yorumModel)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Yorum yorum = new Yorum
                {
                    AdSoyad = yorumModel.AdSoyad,
                    MemnuniyetOyu = yorumModel.MemnuniyetOyu,
                    YorumDetay = yorumModel.Yorum,
                    YorumTarihi = DateTime.Now
                };
                unitOfWork.Yorumlar.Insert(yorum);
                unitOfWork.Complete();

                return Json(new { success = true, message = "Ihr Kommentar wurde erfolgreich gesendet." }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Contact()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Icerik> iletisim = unitOfWork.Icerikler.FindAll(s => s.IcerikKategoriId == 5 && s.DilId == 3).ToList();
                ViewBag.kategori = unitOfWork.Kategoriler.Find(k => k.Id == 5);
                return PartialView("_Contact", iletisim);
            }
        }

        public ActionResult Faq()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Icerik> sss = unitOfWork.Icerikler.FindAll(s => s.IcerikKategoriId == 6 && s.DilId == 3).ToList();
                return PartialView("_Faq", sss);
            }
        }

        [Route("de/AllRegions")]
        public ActionResult AllRegions()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<BolgeDetayViewModel> bolgeler = unitOfWork.BolgeAracFiyatlari.BolgeleriGetir().OrderBy(b => b.BolgeAdi).ToList();
                return View(bolgeler);
            }
        }

        [Route("de/Gallery")]
        public ActionResult Gallery()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Icerik> resimler = unitOfWork.Icerikler.FindAll(g => g.IcerikKategoriId == 9).ToList();
                ViewBag.kategori = unitOfWork.Kategoriler.Find(k => k.Id == 9);
                return View(resimler);
            }
        }

        public ActionResult Slider()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Bolge> alisNoktalari = unitOfWork.Bolgeler.GetAll().ToList();
                List<Bolge> varisNoktalari = unitOfWork.Bolgeler.FindAll(a => a.AlisNoktasiMi == false).OrderBy(c => c.BolgeAdi).ToList();

                SliderRezervDTO rezerv = new SliderRezervDTO
                {
                    AlisNoktasi = new SelectList(alisNoktalari, "Id", "BolgeAdi"),
                    VarisNoktasi = new SelectList(varisNoktalari, "Id", "BolgeAdi")
                };

                ViewBag.slider = unitOfWork.Icerikler.Find(s => s.IcerikKategoriId == 1 && s.DilId == 3);
                ViewBag.images = unitOfWork.Icerikler.FindAll(s => s.IcerikKategoriId == 11).ToList();

                return PartialView("_Slider", rezerv);
            }
        }

        [HttpPost]
        public ActionResult Slider(SliderRezervDTO rezerv)
        {
            RezervasyonViewModel rezervasyonModel = new RezervasyonViewModel();

            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Arac> araclar = unitOfWork.Araclar.GetAll().ToList();
                List<Bolge> alisNoktalari = unitOfWork.Bolgeler.GetAll().OrderBy(c => c.Id).ToList();
                List<Bolge> varisNoktalari = unitOfWork.Bolgeler.FindAll(a => a.AlisNoktasiMi == false).OrderBy(c => c.BolgeAdi).ToList();

                rezervasyonModel.Arac = new SelectList(araclar, "Id", "AracAdi");
                rezervasyonModel.AlisNoktasi = new SelectList(alisNoktalari, "Id", "BolgeAdi", rezerv.AlisNoktasiId);
                rezervasyonModel.VarisNoktasi = new SelectList(varisNoktalari, "Id", "BolgeAdi", rezerv.VarisNoktasiId);
                rezervasyonModel.YetiskinSayisi = rezerv.YetiskinSayisi;
                rezervasyonModel.CocukSayisi = rezerv.CocukSayisi;

                List<Otel> oteller = unitOfWork.Oteller.GetAll().ToList();
                ViewBag.rezervasyonInfo = FiyatBelirleSlider(rezerv.AlisNoktasiId, rezerv.VarisNoktasiId);
                ViewBag.Oteller = oteller;
            }
            return View("Reservation", rezervasyonModel);
        }

        public SliderToRezervationInfoViewModel FiyatBelirleSlider(int alisNoktasiId, int varisNoktasiId)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                SliderToRezervationInfoViewModel info = new SliderToRezervationInfoViewModel();

                BolgeDetayViewModel model = unitOfWork.BolgeAracFiyatlari.BolgeleriGetir(x => x.AracId == 1).Where(f => f.BolgeId == alisNoktasiId).FirstOrDefault();

                if (model != null)
                {
                    info.AlisAdi = model.BolgeAdi;
                    info.VarisAdi = "Antalya";
                }
                else
                {
                    model = unitOfWork.BolgeAracFiyatlari.BolgeleriGetir(x => x.AracId == 1).Where(f => f.BolgeId == varisNoktasiId).FirstOrDefault();

                    info.AlisAdi = "Antalya";
                    info.VarisAdi = model.BolgeAdi;
                }

                info.AracAdi = model.AracAdi;
                info.Fiyat = model.Fiyat.ToString() + " €";

                return info;
            }
        }

        [Route("de/Reservation")]
        public ActionResult Reservation()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                RezervasyonViewModel rezervasyonModel = new RezervasyonViewModel();

                List<Arac> araclar = unitOfWork.Araclar.GetAll().OrderBy(c => c.Id).ToList();
                List<Bolge> alisNoktalari = unitOfWork.Bolgeler.GetAll().OrderBy(c => c.BolgeAdi).ToList();
                List<Bolge> varisNoktalari = unitOfWork.Bolgeler.FindAll(a => a.AlisNoktasiMi == false).OrderBy(c => c.BolgeAdi).ToList();

                rezervasyonModel.Arac = new SelectList(araclar, "Id", "AracAdi");
                rezervasyonModel.AlisNoktasi = new SelectList(alisNoktalari, "Id", "BolgeAdi");
                rezervasyonModel.VarisNoktasi = new SelectList(varisNoktalari, "Id", "BolgeAdi");
                List<Otel> oteller = unitOfWork.Oteller.GetAll().ToList();
                ViewBag.Oteller = oteller;
                return View(rezervasyonModel);
            }
        }

        [HttpPost]
        [Route("de/Reservation")]
        public JsonResult Reservation(RezervasyonBilgileri rezervasyonBilgileri)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                int alisNoktasiId = Convert.ToInt32(rezervasyonBilgileri.AlisNoktasi);
                int varisNoktasiId = Convert.ToInt32(rezervasyonBilgileri.VarisNoktasi);
                int aracId = Convert.ToInt32(rezervasyonBilgileri.AracId);

                Bolge alis = unitOfWork.Bolgeler.FindAll(b => b.Id == alisNoktasiId).First();
                Bolge varis = unitOfWork.Bolgeler.FindAll(b => b.Id == varisNoktasiId).First();
                Arac arac = unitOfWork.Araclar.FindAll(b => b.Id == aracId).First();


                Rezervasyon rezervasyon = new Rezervasyon
                {
                    AdSoyad = rezervasyonBilgileri.AdSoyad,
                    AlisNoktasiId = alisNoktasiId,
                    VarisNoktasiId = varisNoktasiId,
                    AracId = aracId,
                    Fiyat = rezervasyonBilgileri.Fiyat,
                    DilKodu = rezervasyonBilgileri.DilKodu,
                    OtelAdi = rezervasyonBilgileri.OtelAdi,
                    GelisTarihi = Convert.ToDateTime(rezervasyonBilgileri.GelisZamani),
                    GelisUcusNumarasi = rezervasyonBilgileri.UcusNumarasi,
                    Telefon = rezervasyonBilgileri.Telefon,
                    Email = rezervasyonBilgileri.Email,
                    OzelNot = rezervasyonBilgileri.OzelNot,
                    YetiskinSayisi = Convert.ToInt32(rezervasyonBilgileri.YetiskinSayisi),
                    CocukSayisi = Convert.ToInt32(rezervasyonBilgileri.CocukSayisi),
                    CocukKoltuguSayisi = Convert.ToInt32(rezervasyonBilgileri.CocukKoltuguSayisi),
                    RezervasyonOnay = false,
                    KayitTarihi = DateTime.Now
                };

                var donusUcusNumarasi = (rezervasyonBilgileri.DonusUcusNumarasi == null) ? "-" : rezervasyonBilgileri.DonusUcusNumarasi;

                if (rezervasyonBilgileri.DonusZamani != null)
                {
                    rezervasyon.DonusTarihi = Convert.ToDateTime(rezervasyonBilgileri.DonusZamani);
                    rezervasyon.DonusUcusNumarasi = rezervasyonBilgileri.DonusUcusNumarasi;
                }
                unitOfWork.Rezervasyonlar.Insert(rezervasyon);
                unitOfWork.Complete();

                string kisiIsimleri = null;
                if (rezervasyonBilgileri.KisiBilgileri != null)
                {
                    foreach (var kisi in rezervasyonBilgileri.KisiBilgileri)
                    {
                        if (kisiIsimleri != null)
                        {
                            kisiIsimleri = kisiIsimleri + ", ";
                        }

                        RezervasyonKisi rezervKisi = new RezervasyonKisi
                        {
                            AdSoyad = kisi.AdSoyad,
                            YetiskinMi = Convert.ToBoolean(kisi.YetiskinMi),
                            Rezervasyon = rezervasyon
                        };

                        kisiIsimleri = kisiIsimleri + kisi.AdSoyad;

                        unitOfWork.GelenKisiler.Insert(rezervKisi);
                        unitOfWork.Complete();
                    }
                }

                #region Mesaj Body Oluşturuldu


                string body = "<div style='display: flex; flex-direction: column; align-items: stretch; justify-content: stretch; font-family:arial,helvetica,sans-serif;'>" +
                                    "<h3 style='background-color: #19335c; color: #f5b754; padding:30px; text-align: center; font-size: 24px; margin: 0;'>Imperial VIP Transfer</h3>" +
                                    "<h6 style='background-color: #19335c; color: #f5b754; padding-bottom:30px; text-align: center; font-size: 15px; font-weight: 300; margin: 0;'>Rezervasyon Detayları</h6>" +
                                    "<table style='padding: 20px;'>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Adı Soyadı : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{rezervasyonBilgileri.AdSoyad}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Telefon Numarası : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{rezervasyonBilgileri.Telefon}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>E-posta Adresi : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{rezervasyonBilgileri.Email}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Gelen Kişi Bilgileri : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{kisiIsimleri}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Alış Noktası : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{alis.BolgeAdi}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Varış Noktası : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{varis.BolgeAdi}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Araç Türü : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{arac.AracAdi}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Preis : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{rezervasyonBilgileri.Fiyat}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Otel Adı : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{rezervasyonBilgileri.OtelAdi}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Geliş Zamanı : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{Convert.ToDateTime(rezervasyonBilgileri.GelisZamani).ToShortDateString()} - {Convert.ToDateTime(rezervasyonBilgileri.GelisZamani).ToShortTimeString()}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Uçuş Numarası : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{rezervasyonBilgileri.UcusNumarasi}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Dönüş Zamanı : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{(rezervasyon.DonusTarihi == null ? " - " : Convert.ToDateTime(rezervasyon.DonusTarihi).ToShortDateString())}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Dönüş Uçuş Numarası : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{donusUcusNumarasi}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Kişi Sayısı : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{Convert.ToInt32(rezervasyonBilgileri.YetiskinSayisi)} Yetişkin - {Convert.ToInt32(rezervasyonBilgileri.CocukSayisi)} Çocuk </td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Çocuk Koltuğu Sayısı : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{Convert.ToInt32(rezervasyonBilgileri.CocukKoltuguSayisi)}</td>" +
                                        "</tr>" +
                                        "<tr style='line-height: 35px; text-align: left;'>" +
                                            "<td style='border-bottom: 1px solid #19335c; width: 150px; padding-left: 10px;'><strong>Mesajı : </strong></td>" +
                                            $"<td style='border-bottom: 1px solid #19335c; padding-left: 10px;'>{rezervasyonBilgileri.OzelNot}</td>" +
                                        "</tr>" +
                                    "</table>" +
                                "</div>";
                #endregion


                if (MailHelper.SendRezervasyonMail(body))
                {
                    return Json(new { success = true, message = "Ihre Reservierungsanfrage wurde empfangen." }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { success = false, message = "Ihre Reservierungsanfrage konnte aufgrund eines Problems nicht empfangen werden." }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("de/VarisNoktasiBelirle")]
        public JsonResult VarisNoktasiBelirle(int alisNoktasiId)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Bolge alisNoktasi = unitOfWork.Bolgeler.Get(alisNoktasiId);
                List<Bolge> varisNoktalari = unitOfWork.Bolgeler.GetAll().OrderBy(c => c.BolgeAdi).ToList();

                List<SelectListItem> varisNoktalarListesi = new List<SelectListItem>();

                if (alisNoktasi.AlisNoktasiMi)
                {
                    varisNoktalarListesi = (from v in varisNoktalari
                                            where v.AlisNoktasiMi == false
                                            select new SelectListItem
                                            {
                                                Text = v.BolgeAdi,
                                                Value = v.Id.ToString()
                                            }).ToList();
                }
                else
                {
                    varisNoktalarListesi = (from v in varisNoktalari
                                            where v.AlisNoktasiMi == true
                                            select new SelectListItem
                                            {
                                                Text = v.BolgeAdi,
                                                Value = v.Id.ToString()
                                            }).ToList();
                }
                return Json(varisNoktalarListesi, JsonRequestBehavior.AllowGet);

            }
        }

        [Route("de/FiyatBelirle")]
        public JsonResult FiyatBelirle(int alisNoktasiId, int varisNoktasiId, int aracId, string changeMod)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                string aracTuru = "";
                string alisNoktasi = "";
                string varisNoktasi = "";
                float bolgeFiyat = 0;

                BolgeDetayViewModel model = unitOfWork.BolgeAracFiyatlari.BolgeleriGetir(x => x.AracId == aracId).Where(x => x.BolgeId == alisNoktasiId).FirstOrDefault();

                if (model == null && changeMod == "1")
                {
                    model = unitOfWork.BolgeAracFiyatlari.BolgeleriGetir(x => x.AracId == aracId).OrderBy(x => x.BolgeAdi).FirstOrDefault();
                    alisNoktasi = "Antalya";
                    varisNoktasi = model.BolgeAdi;
                    aracTuru = model.AracAdi;
                    bolgeFiyat = model.Fiyat;
                    return Json(new
                    {
                        result = true,
                        fiyat = bolgeFiyat,
                        alis = alisNoktasi,
                        varis = varisNoktasi,
                        arac = aracTuru
                    }, JsonRequestBehavior.AllowGet);
                }

                if (alisNoktasiId == varisNoktasiId && model != null && changeMod == "1")
                {
                    alisNoktasi = model.BolgeAdi;
                    varisNoktasi = "Antalya";
                    aracTuru = model.AracAdi;
                    bolgeFiyat = model.Fiyat;
                    return Json(new
                    {
                        result = true,
                        fiyat = bolgeFiyat,
                        alis = alisNoktasi,
                        varis = varisNoktasi,
                        arac = aracTuru
                    }, JsonRequestBehavior.AllowGet);
                }

                if (model == null && (changeMod == "2" || changeMod == "3"))
                {
                    model = unitOfWork.BolgeAracFiyatlari.BolgeleriGetir(x => x.AracId == aracId).Where(x => x.BolgeId == varisNoktasiId).FirstOrDefault();
                    alisNoktasi = "Antalya";
                    varisNoktasi = model.BolgeAdi;
                    aracTuru = model.AracAdi;
                    bolgeFiyat = model.Fiyat;

                    return Json(new
                    {
                        result = true,
                        fiyat = bolgeFiyat,
                        alis = alisNoktasi,
                        varis = varisNoktasi,
                        arac = aracTuru
                    }, JsonRequestBehavior.AllowGet);
                }

                alisNoktasi = model.BolgeAdi;
                varisNoktasi = "Antalya";
                aracTuru = model.AracAdi;
                bolgeFiyat = model.Fiyat;

                return Json(new
                {
                    result = true,
                    fiyat = bolgeFiyat,
                    alis = alisNoktasi,
                    varis = varisNoktasi,
                    arac = aracTuru
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
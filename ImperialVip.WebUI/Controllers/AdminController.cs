using ImperialVip.Business;
using ImperialVip.Business.Interfaces;
using ImperialVip.Business.UnitOfWork;
using ImperialVip.Common;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.ViewModels;
using ImperialVip.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImperialVip.WebUI.Controllers
{

    [Auth]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RezervasyonIslemleri()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<RezervasyonModel> rezervler = unitOfWork.Rezervasyonlar.RezervasyonGetir().OrderByDescending(r => r.Id).ToList();
                return View(rezervler);
            }
        }

        public ActionResult RezervasyonDetay(int id)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                RezervasyonModel rezerv = unitOfWork.Rezervasyonlar.RezervasyonGetirById(id);
                List<RezervasyonKisi> kisiler = unitOfWork.GelenKisiler.FindAll(k => k.RezervasyonId == id).ToList();
                string kisiIsimleri = null;

                foreach (var kisi in kisiler)
                {
                    if (kisiIsimleri != null)
                    {
                        kisiIsimleri = kisiIsimleri + ", ";
                    }

                    kisiIsimleri = kisiIsimleri + kisi.AdSoyad;
                }
                if (kisiIsimleri != null)
                {
                    ViewBag.kisiIsimleri = kisiIsimleri;
                }
                else
                {

                    ViewBag.kisiIsimleri = "-";
                }
                return View(rezerv);
            }
        }

        public ActionResult RezervasyonOnay(int id)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Rezervasyon rezerv = unitOfWork.Rezervasyonlar.Get(id);

                List<RezervasyonKisi> kisiler = unitOfWork.GelenKisiler.FindAll(k => k.RezervasyonId == rezerv.Id).ToList();
                string kisiIsimleri = null;

                foreach (var kisi in kisiler)
                {
                    if (kisiIsimleri != null)
                    {
                        kisiIsimleri = kisiIsimleri + ", ";
                    }

                    kisiIsimleri = kisiIsimleri + kisi.AdSoyad;
                }
                rezerv.RezervasyonOnay = true;
                unitOfWork.Rezervasyonlar.Update(rezerv);
                unitOfWork.Complete();
                string body = "";

                string trBody = "<div style='font-family:arial,helvetica,sans-serif;'>" +
                                    "<h3 style='background-color: #19335c; color: #f5b754; padding:30px; text-align: center; font-size: 24px; margin: 0;'>Imperial VIP Transfer</h3>" +
                                    "<h6 style='background-color: #19335c; color: #f5b754; padding-bottom:30px; text-align: center; font-size: 15px; font-weight: 300; margin: 0;'>Rezervasyon Detayları</h6>" +
                                    "<div>" +
                                        "<p style='text-align: center;'>Merhaba Sayın " + rezerv.AdSoyad + ",</p>" +
                                        "<p style='text-align: center;'>Imperial VIP Transfer rezervasyon talebiniz onaylanmıştır. Sizinle iletişime geçilecektir.</p>" +
                                        "<p style='text-align: center;'>İyi günler dileriz.</p>" +
                                    "</div>" +
                                "</div>";

                string enBody = "<div style='font-family:arial,helvetica,sans-serif;'>" +
                                    "<h3 style='background-color: #19335c; color: #f5b754; padding:30px; text-align: center; font-size: 24px; margin: 0;'>Imperial VIP Transfer</h3>" +
                                    "<h6 style='background-color: #19335c; color: #f5b754; padding-bottom:30px; text-align: center; font-size: 15px; font-weight: 300; margin: 0;'>Reservation Details</h6>" +
                                    "<div>" +
                                        "<p style='text-align: center;'>Hello " + rezerv.AdSoyad + ",</p>" +
                                        "<p style='text-align: center;'>Your Imperial VIP Transfer reservation request has been approved. You will be contacted.</p>" +
                                        "<p style='text-align: center;'>We wish you a good day.</p>" +
                                    "</div>" +
                                "</div>";

                string deBody = "<div style='font-family:arial,helvetica,sans-serif;'>" +
                                    "<h3 style='background-color: #19335c; color: #f5b754; padding:30px; text-align: center; font-size: 24px; margin: 0;'>Imperial VIP Transfer</h3>" +
                                    "<h6 style='background-color: #19335c; color: #f5b754; padding-bottom:30px; text-align: center; font-size: 15px; font-weight: 300; margin: 0;'>Reservierungsdetails</h6>" +
                                    "<div>" +
                                        "<p style='text-align: center;'>Hallo " + rezerv.AdSoyad + ",</p>" +
                                        "<p style='text-align: center;'>Ihre Reservierungsanfrage für den Imperial VIP Transfer wurde genehmigt. Sie werden kontaktiert.</p>" +
                                        "<p style='text-align: center;'>Wir wünschen Ihnen einen schönen Tag.</p>" +
                                    "</div>" +
                                "</div>";

                string ruBody = "<div style='font-family:arial,helvetica,sans-serif;'>" +
                                    "<h3 style='background-color: #19335c; color: #f5b754; padding:30px; text-align: center; font-size: 24px; margin: 0;'>Imperial VIP Transfer</h3>" +
                                    "<h6 style='background-color: #19335c; color: #f5b754; padding-bottom:30px; text-align: center; font-size: 15px; font-weight: 300; margin: 0;'>Подробности бронирования</h6>" +
                                    "<div>" +
                                        "<p style='text-align: center;'>Привет " + rezerv.AdSoyad + ",</p>" +
                                        "<p style='text-align: center;'>Ваш запрос на бронирование Imperial VIP Transfer одобрен. С вами свяжутся.</p>" +
                                        "<p style='text-align: center;'>Желаем вам хорошего дня.</p>" +
                                    "</div>" +
                                "</div>";

                if (rezerv.DilKodu == "tr")
                {
                    body = trBody;
                }

                if (rezerv.DilKodu == "en")
                {
                    body = enBody;
                }

                if (rezerv.DilKodu == "de")
                {
                    body = deBody;
                }

                if (rezerv.DilKodu == "ru")
                {
                    body = ruBody;
                }

                MailHelper.SendMail(body, rezerv.Email, "Imperial VIP Transfer - Rezervasyon");
                ViewBag.kisiIsimleri = kisiIsimleri;
                return RedirectToAction("RezervasyonIslemleri");
            }
        }

        public ActionResult RezervasyonSil(int id)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Rezervasyon rezerv = unitOfWork.Rezervasyonlar.Find(r => r.Id == id);
                List<RezervasyonKisi> kisiler = unitOfWork.GelenKisiler.FindAll(k => k.RezervasyonId == id).ToList();
                foreach (var item in kisiler)
                {
                    unitOfWork.GelenKisiler.Delete(item);
                }

                unitOfWork.Rezervasyonlar.Delete(rezerv);
                unitOfWork.Complete();

                return RedirectToAction("YorumIslemleri");
            }
        }

        public ActionResult Logo()
        {
            Icerik logo = new Icerik();
            return View(logo);
        }

        public ActionResult Slider()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<IcerikViewModel> sliderlar = unitOfWork.Icerikler.GetSliders().ToList();
                ViewBag.resimler = unitOfWork.Icerikler.FindAll(r => r.IcerikKategoriId == 11).ToList();
                return View(sliderlar);
            }

        }

        [HttpPost]
        public ActionResult SliderGuncelle(IcerikDuzenleViewModel model)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Icerik guncellenecek = unitOfWork.Icerikler.Find(i => i.Id == model.Id);
                guncellenecek.IcerikBaslik = model.IcerikBaslik;
                guncellenecek.IcerikDetay = model.IcerikDetay;
                unitOfWork.Icerikler.Update(guncellenecek);
                unitOfWork.Complete();
                return RedirectToAction("Slider");
            }
        }

        public ActionResult SliderEkleModal()
        {
            return PartialView("_SliderEkleModal");
        }

        [HttpPost]
        public ActionResult SliderEkle(HttpPostedFileBase imgFile)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                // Sonra yeni eklenmek istenen resim yükleniyor.
                var imgCount = unitOfWork.Icerikler.FindAll(g => g.IcerikKategoriId == 11).Count();
                string imgUrl = "slider/slider-" + (DateTime.Now.ToString().Replace(':', '_')) + "." + imgFile.ContentType.Split('/')[1];
                string savePath = Server.MapPath("~/Content/imgs/" + imgUrl);
                imgFile.SaveAs(savePath);

                Icerik icerik = new Icerik
                {
                    DilId = 1,
                    IcerikKategoriId = 11,
                    IcerikBaslik = imgFile.ContentType.Split('/')[0],
                    ResimUrl = imgUrl
                };

                unitOfWork.Icerikler.Insert(icerik);
                unitOfWork.Complete();

                return RedirectToAction("Slider");
            }
        }

        public ActionResult SliderSil(int id)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Icerik resim = unitOfWork.Icerikler.FindAll(g => g.Id == id).FirstOrDefault();
                string fullPath = Request.MapPath("~/Content/imgs/" + resim.ResimUrl);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                unitOfWork.Icerikler.Delete(resim);
                unitOfWork.Complete();

                return RedirectToAction("Slider");

            }
        }

        public ActionResult Hizmetler()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Icerik> hizmetler = unitOfWork.Icerikler.FindAll(k => k.IcerikKategoriId == 2).ToList();
                return View(hizmetler);
            }
        }

        public ActionResult Hakkimizda()
        {
            List<Icerik> hakkimizda = new List<Icerik>();
            return View(hakkimizda);
        }

        public ActionResult NedenBiz()
        {
            List<Icerik> nedenBiz = new List<Icerik>();
            return View(nedenBiz);
        }

        public ActionResult Iletisim()
        {
            List<Icerik> iletisim = new List<Icerik>();
            return View(iletisim);
        }

        public ActionResult Sss()
        {
            List<Icerik> sss = new List<Icerik>();
            return View(sss);
        }

        public ActionResult GaleriIslemleri()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Icerik> resimler = unitOfWork.Icerikler.FindAll(g => g.IcerikKategoriId == 9).ToList();
                return View(resimler);
            }
        }

        public ActionResult ResimEkleModal()
        {
            return PartialView("_ResimEkleModal");
        }

        [HttpPost]
        public ActionResult ResimEkle(HttpPostedFileBase imgFile)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                var imgCount = unitOfWork.Icerikler.FindAll(g => g.IcerikKategoriId == 9).Count();
                string imgUrl = "galeri/image-" + (DateTime.Now.ToString().Replace(':', '_')) + "." + imgFile.ContentType.Split('/')[1];
                string savePath = Server.MapPath("~/Content/imgs/" + imgUrl);

                imgFile.SaveAs(savePath);

                Icerik icerik = new Icerik
                {
                    DilId = 1,
                    IcerikKategoriId = 9,
                    IcerikBaslik = imgFile.ContentType.Split('/')[0],
                    ResimUrl = imgUrl
                };

                unitOfWork.Icerikler.Insert(icerik);
                unitOfWork.Complete();

                return RedirectToAction("GaleriIslemleri");

            }
        }

        public ActionResult ResimSil(int id)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Icerik resim = unitOfWork.Icerikler.FindAll(g => g.Id == id).FirstOrDefault();
                string fullPath = Request.MapPath("~/Content/imgs/" + resim.ResimUrl);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                unitOfWork.Icerikler.Delete(resim);
                unitOfWork.Complete();

                return RedirectToAction("GaleriIslemleri");

            }
        }

        public ActionResult Bolgeler()
        {
            List<Bolge> bolgeler = new List<Bolge>();
            return View(bolgeler);
        }

        public ActionResult Footer()
        {
            Icerik footer = new Icerik();
            return View(footer);
        }

        public ActionResult BizeUlasinMailleri()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<BizUlasinMail> mailler = unitOfWork.BizeUlasinMailler.GetAll().OrderByDescending(m => m.Id).ToList();
                return View(mailler);
            }
        }

        public ActionResult BizeUlasinMailSil(int id)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                BizUlasinMail mail = unitOfWork.BizeUlasinMailler.Find(o => o.Id == id);
                unitOfWork.BizeUlasinMailler.Delete(mail);
                unitOfWork.Complete();
                return RedirectToAction("BizeUlasinMailleri");
            }
        }

        public ActionResult BizeUlasinModal()
        {
            BizUlasinMail bizeUlasinModel = new BizUlasinMail();
            return PartialView("_BizeUlasinModal", bizeUlasinModel);
        }

        public ActionResult BolgeIslemleri()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<BolgeDetayViewModel> bolgeFiyatList = unitOfWork.BolgeAracFiyatlari.BolgeleriGetir().OrderBy(x => x.BolgeAdi).ToList();
                return View(bolgeFiyatList);
            }
        }

        public ActionResult YorumIslemleri()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Yorum> yorumlar = unitOfWork.Yorumlar.GetAll().OrderByDescending(y => y.YorumTarihi).OrderBy(y => y.OnayDurumu).Take(10).ToList();
                return View(yorumlar);
            }
        }

        public ActionResult YorumOnayla(int id)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Yorum yorum = unitOfWork.Yorumlar.FindAll(y => y.Id == id).FirstOrDefault();
                yorum.OnayDurumu = true;
                unitOfWork.Yorumlar.Update(yorum);
                unitOfWork.Complete();
                return RedirectToAction("YorumIslemleri", "Admin");
            }
        }
        
        public ActionResult YorumSil(int id)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Yorum yorum = unitOfWork.Yorumlar.Find(o => o.Id == id);
                unitOfWork.Yorumlar.Delete(yorum);
                unitOfWork.Complete();
                return RedirectToAction("YorumIslemleri");
            }
        }

        public ActionResult OtelIslemleri()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                List<Otel> oteller = unitOfWork.Oteller.GetAll().OrderBy(y => y.OtelAdi).ToList();
                return View(oteller);
            }
        }

        public ActionResult OtelEkleModal()
        {
            Otel otel = new Otel();
            return PartialView("_OtelEkleModal", otel);
        }

        [HttpPost]
        public ActionResult OtelEkle(Otel otel)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                unitOfWork.Oteller.Insert(otel);
                unitOfWork.Complete();
                return RedirectToAction("OtelIslemleri");
            }
        }

        public ActionResult OtelSil(int id)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                Otel otel = unitOfWork.Oteller.Find(o => o.Id == id);
                unitOfWork.Oteller.Delete(otel);
                unitOfWork.Complete();
                return RedirectToAction("OtelIslemleri");
            }
        }

        public ActionResult BolgeEkleModal()
        {
            Bolge bolge = new Bolge();
            return PartialView("_BolgeEkleModal", bolge);
        }

        public ActionResult BolgeFiyatlandir()
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                BolgeFiyatViewModel bolgeFiyat = new BolgeFiyatViewModel();

                List<Arac> araclar = unitOfWork.Araclar.GetAll().OrderBy(c => c.AracAdi).ToList();
                List<Bolge> alisNoktalari = unitOfWork.Bolgeler.GetAll().OrderBy(c => c.BolgeAdi).ToList();
                List<Bolge> varisNoktalari = unitOfWork.Bolgeler.FindAll(a => a.AlisNoktasiMi == false).OrderBy(c => c.BolgeAdi).ToList();

                bolgeFiyat.Araclar = new SelectList(araclar, "Id", "AracAdi");
                bolgeFiyat.Bolgeler = new SelectList(alisNoktalari, "Id", "BolgeAdi");

                Bolge bolge = new Bolge();
                return PartialView("_BolgeFiyatlandirModal", bolgeFiyat);
            }
        }

        [HttpPost]
        public ActionResult BolgeFiyatlandir(BolgeFiyatViewModel bolgeFiyatModel)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                BolgeyeGoreAracFiyat bolgeFiyat = new BolgeyeGoreAracFiyat()
                {
                    BolgeId = bolgeFiyatModel.BolgeId,
                    AracId = bolgeFiyatModel.AracId,
                    Fiyat = bolgeFiyatModel.Fiyat
                };

                unitOfWork.BolgeAracFiyatlari.Insert(bolgeFiyat);
                unitOfWork.Complete();

                return RedirectToAction("BolgeIslemleri");
            }
        }

        [HttpPost]
        public ActionResult BolgeEkle(Bolge bolge, HttpPostedFileBase imgFile)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                var imgCount = unitOfWork.Bolgeler.FindAll(g => g.AlisNoktasiMi).Count();
                var imgUrl = "location/location-" + (DateTime.Now.ToString().Replace(':', '_')) + "." + imgFile.ContentType.Split('/')[1];
                string savePath = Server.MapPath("~/Content/imgs/" + imgUrl);
                string path = Server.MapPath("~/Content/imgs/" + imgFile.FileName);
                imgFile.SaveAs(path);

                bolge.ResimUrl = imgUrl;
                unitOfWork.Bolgeler.Insert(bolge);
                unitOfWork.Complete();

                return RedirectToAction("BolgeIslemleri");
            }
        }

        public ActionResult BolgeFiyatSil(int id)
        {
            using (var unitOfWork = new UnitOfWork(new ImperialDatabaseContext()))
            {
                BolgeyeGoreAracFiyat bolgeFiyat = unitOfWork.BolgeAracFiyatlari.Find(o => o.Id == id);
                unitOfWork.BolgeAracFiyatlari.Delete(bolgeFiyat);
                unitOfWork.Complete();
                return RedirectToAction("BolgeIslemleri");
            }
        }
    }
}
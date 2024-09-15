
using ImperialVip.Business.Interfaces;
using ImperialVip.DataAccess;
using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;
using ImperialVip.DataAccess.ViewModels;
using System.Linq;
using System.Web.Helpers;

namespace ImperialVip.Business
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public ImperialDatabaseContext Context
        {
            get { return _context as ImperialDatabaseContext; }
        }

        public KullaniciRepository(ImperialDatabaseContext context) : base(context)
        {
        }

        private IslemSonucu<Kullanici> sonuc = new IslemSonucu<Kullanici>();

        public IslemSonucu<Kullanici> LoginMember(LoginViewModel model)
        {
            if (model.Username == null)
            {
                sonuc.Hatalar.Add("Email adresi girmelisiniz!");
            }
            else
            {
                sonuc.Sonuc = Context.Kullanicilar.Where(k => k.Username == model.Username).FirstOrDefault();

                if (sonuc.Sonuc == null)
                {
                    sonuc.Hatalar.Add("Kullanıcı adı bulunamadı !");

                }
                else
                {
                    if (!sonuc.Sonuc.AktifMi)
                    {
                        sonuc.Hatalar.Add("Pasif kullanıcı sisteme giriş yapamamaktadır.");
                    }

                    if (model.Password != null)
                    {
                        var hashPassword = Encrypt(model.Password);

                        if (sonuc.Sonuc.Password != hashPassword)
                        {
                            sonuc.Hatalar.Add("Şifrenizi yanlış girdiniz!");
                        }
                    }
                    else
                    {
                        sonuc.Hatalar.Add("Şifrenizi boş geçemezsiniz!");
                    }
                }
            }
            return sonuc;
        }

        public string Encrypt(string password)
        {
            var hash = Crypto.Hash(password, "SHA-256");
            return hash;
        }
    }
}

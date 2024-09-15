using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;
using ImperialVip.DataAccess.ViewModels;

namespace ImperialVip.Business.Interfaces
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        IslemSonucu<Kullanici> LoginMember(LoginViewModel model);
        string Encrypt(string password);
    }
}

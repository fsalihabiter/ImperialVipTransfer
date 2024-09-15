using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;
using ImperialVip.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.Business.Interfaces
{
    public interface IRezervasyonRepository : IRepository<Rezervasyon>
    {
        List<RezervasyonModel> RezervasyonGetir();

        RezervasyonModel RezervasyonGetirById(int id);
    }
}

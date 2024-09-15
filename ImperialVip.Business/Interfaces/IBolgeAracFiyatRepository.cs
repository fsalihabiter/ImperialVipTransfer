using ImperialVip.DataAccess.Entities;
using ImperialVip.DataAccess.EntityFramework;
using ImperialVip.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.Business.Interfaces
{
    public interface IBolgeAracFiyatRepository : IRepository<BolgeyeGoreAracFiyat>
    {
        IEnumerable<BolgeDetayViewModel> BolgeleriGetir();
        IEnumerable<BolgeDetayViewModel> BolgeleriGetir(Expression<Func<BolgeyeGoreAracFiyat, bool>> predicate);
    }
}

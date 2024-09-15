using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImperialVip.DataAccess.ViewModels
{

    public class IslemSonucu<T> where T : class
    {
        public List<string> Hatalar { get; set; }
        public T Sonuc { get; set; }

        public IslemSonucu()
        {
            Hatalar = new List<string>();
        }
    }
}

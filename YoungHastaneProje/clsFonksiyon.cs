using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoungHastaneProje
{
    class clsFonksiyon
    {
        public static string FormatDuzenle(string Deger)
        {
            Deger = !String.IsNullOrEmpty(Deger) ? Deger.Replace(".", "").Replace(",", ".") : "0";
            return Deger; // beni mi bekliyorsun abi 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapMagzasiClassLib.Classes
{
    public class Satis
    {
        public Satis(Kitap alınanKitap, Kullanici satinAlanKullanici, DateTime satisTarihi, bool hediyeMi)
        {
            AlınanKitap = alınanKitap;
            SatinAlanKullanici = satinAlanKullanici;
            SatisTarihi = satisTarihi;
            HediyeMi = hediyeMi;
        }

        public string SatisId { get; set; }
        public Kitap AlınanKitap { get; set; }
        public Kullanici SatinAlanKullanici { get; set; }
        public DateTime SatisTarihi { get; set; }
        public bool HediyeMi { get; set; }
    }
}

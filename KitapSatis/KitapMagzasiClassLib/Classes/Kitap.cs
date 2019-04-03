using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapMagzasiClassLib.Classes
{
    public class Kitap
    {
        public Kitap(string adi, Yazar yazar, KitapTuru kitapTuru, int sayfaSayisi, double fiyat, YayinEvi yayinEvi, int baskiYili)
        {
            Adi = adi;
            Yazar = yazar;
            KitapTuru = kitapTuru;
            SayfaSayisi = sayfaSayisi;
            Fiyat = fiyat;
            YayinEvi = yayinEvi;
            BaskiYili = baskiYili;
            KitapId = Guid.NewGuid().ToString();
        }

        public string KitapId { get; set; }
        public string Adi { get; set; }
        public Yazar Yazar { get; set; }
        public KitapTuru KitapTuru { get; set; }
        public int SayfaSayisi { get; set; }
        public double Fiyat { get; set; }
        public YayinEvi YayinEvi { get; set; }
        public int BaskiYili { get; set; }


    }
}

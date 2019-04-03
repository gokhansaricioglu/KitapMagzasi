using System;

namespace KitapMagzasiClassLib.Classes
{
    public class Kullanici
    {
        public Kullanici(string adi, string soyadi, string kullaniciAdi, string sifre
            )
        {
            Adi = adi;
            Soyadi = soyadi;
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
            KullaniciId = Guid.NewGuid().ToString();
        }

        public string KullaniciId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

    }
}

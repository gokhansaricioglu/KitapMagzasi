using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapMagzasiClassLib.Classes
{
    public static class FakeDb
    {
        public static List<Kitap> Kitaplar = new List<Kitap>();
        public static List<Kullanici> Kullaniciler = new List<Kullanici>();
        public static List<Satis> Satislar = new List<Satis>();
        public static List<YayinEvi> Yayinevleri = new List<YayinEvi>();
        public static List<Yazar> Yazarlar = new List<Yazar>();
        public static void FakeDataOlustur()
        {
            Kullanici mahmut = new Kullanici("mahmut", "tuncer", "halay", "123456");
            Kullanici omer = new Kullanici("omer", "tunher", "dana", "123456");
            Kullanici osla = new Kullanici("osla", "kvsz", "oslakvsz", "123456");
            Kullanici stndrt = new Kullanici("Stan", "Dart", "stdin", "123456");
            Kullaniciler.Add(mahmut);
            Kullaniciler.Add(omer);
            Kullaniciler.Add(osla);
            Kullaniciler.Add(stndrt);

            var kitapIsimleri = File.ReadAllLines(@"kitapIsim.txt");
            var yayinEviIsimleri = File.ReadAllLines(@"yayinEviIsim.txt");
            var yazarIsimleri = File.ReadAllLines(@"yazarIsim.txt");
            Random rnd = new Random();

            for (int i = 0; i <  7; i++)
            {
                int currentYazarIndis = rnd.Next(yazarIsimleri.Length);
                DateTime dogumTarihi = new DateTime(rnd.Next(1900, 1980), rnd.Next(1, 13), rnd.Next(1, 29));
                Yazarlar.Add(new Yazar(yazarIsimleri[currentYazarIndis], dogumTarihi));
            }
            for (int i = 0; i < yayinEviIsimleri.Length; i++)
            {
                Yayinevleri.Add(new YayinEvi(yayinEviIsimleri[i]));
            }

            for (int i = 0; i < kitapIsimleri.Length; i++)
            {
                Yazar yazar = Yazarlar[rnd.Next(Yazarlar.Count)];
                KitapTuru kitapTuru = (KitapTuru)rnd.Next(7);
                int sayfaSayisi = rnd.Next(200, 1200);
                double fiyat = rnd.Next(10,45);
                YayinEvi yayinEvi = Yayinevleri[rnd.Next(Yayinevleri.Count)];
                int baskiYili = rnd.Next(1950, 2019);
                Kitaplar.Add(new Kitap(kitapIsimleri[i],yazar,kitapTuru,sayfaSayisi,fiyat,yayinEvi,baskiYili));
            }

            for (int i = 0; i < 200; i++)
            {
                var alinanKitap = Kitaplar[rnd.Next(0, Kitaplar.Count)];
                var satinAlanKullanici = Kullaniciler[rnd.Next(0, Kullaniciler.Count)];
                DateTime satisTarihi = new DateTime(rnd.Next(2017, 2020), rnd.Next(1, 13), rnd.Next(1, 29));
                bool hediyeMi = Convert.ToBoolean(rnd.Next(0, 2));
                Satislar.Add(new Satis(alinanKitap, satinAlanKullanici, satisTarihi, hediyeMi));
            }
        }

    }
}

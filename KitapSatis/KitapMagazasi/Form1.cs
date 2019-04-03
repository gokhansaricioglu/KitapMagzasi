using KitapMagzasiClassLib.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitapMagazasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FakeDb.FakeDataOlustur();
            CbKitapTur.DataSource = Enum.GetNames(typeof(KitapTuru));
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            //Kullanici adi ve şifre FakeDB'de var ise mbox'a Hoşgeldin Adi + " " + Soyadi
            //Kullanici adi ve şifre FakeDB'de yok ise mbox'a Ka ve veya Şifre Hatalı

            var kullanicigirisi = FakeDb.Kullaniciler.Any(x => x.KullaniciAdi == TbKullaniciAdi.Text && x.Sifre == TbSifre.Text);
            if (kullanicigirisi == true)
            {
                MessageBox.Show("Kullanici Girisi Yapildi");
            }
            else
            {
                MessageBox.Show("Girilen ID veya Sifre Hatali");
            }


        }

        private void BtnSifremiUnuttum_Click(object sender, EventArgs e)
        {
            //Kullanici adi FakeDB'de var ise mbox'a Şifreyi Yaz
            //Kullanici adi FakeDb'de yok ise mbox'a Böyle Bir Kullanici Yok Yaz

            var sifremiunuttum = FakeDb.Kullaniciler.Where(x => x.KullaniciAdi == TbKullaniciAdi.Text);

            bool sifre = Convert.ToBoolean(sifremiunuttum);

            if (sifre == true)
            {
                MessageBox.Show(FakeDb.Kullaniciler.Select(x => x.Sifre).ToString());
            }
            else { MessageBox.Show("Böyle Kullanici Yok"); }


        }

        private void BtnYazarKitapGetir_Click(object sender, EventArgs e)
        {
            // TbYazarAdi'na girilen Yazarın Tüm kitaplarını getir ve LbSonuc'a Kitabın adını ve Fiyatını Yaz
            // var sifremiunuttum = FakeDb.Kullaniciler.Where(x => x.KullaniciAdi == TbKullaniciAdi.Text);
            var yazar = FakeDb.Kitaplar.Where(x => x.Yazar.AdiSoyadi == TbYazarAdi.Text)
                .Select(a => new { a.Adi, a.Fiyat });
            LbSonuc.DataSource = yazar.ToList();
            
        }

        private void BtnTumKitapSatisAded_Click(object sender, EventArgs e)
        {
            //Tüm Kitap Türlerinin ayrı ayrı kaç adet sattığını ve KitapTürünü LbSonuc'ta listeleyin


            var kitapciklar = FakeDb.Kitaplar.GroupBy(x => x.KitapTuru)
                 .Select(y => new
                 {
                     KitapTuru = y.Key,
                     Count = y.Count()
                 }).OrderBy(a => a.KitapTuru);
            //MessageBox.Show(kitapciklar.KitapTuru + " " + kitapciklar.Count);
            LbSonuc.DataSource = kitapciklar.ToList();
        }

        private void BtnYazarKitapSayfa_Click(object sender, EventArgs e)
        {
            // TbYazarAdi'na girilen Yazarın Tüm kitaplarının ortalama sayfa adedini mbox'a Yazdır

            var kitaplar = FakeDb.Kitaplar.GroupBy(x => x.Yazar.AdiSoyadi,
                (key, list) =>
                {
                    return new
                    {
                        KitapAdi = key,
                        AVG = list.Average(x=> x.SayfaSayisi)
                    };
                });
            foreach (var item in kitaplar)
            {
                MessageBox.Show(item.KitapAdi + " " + item.AVG);
            }


        }

        private void BtnYazarKitapTur_Click(object sender, EventArgs e)
        {
            // TbYazarAdi'na girilen Yazarın hangi türde kaç adet kitabı olduğunu LbSonuc'ta listeleyin

            var kitaplaaar = FakeDb.Kitaplar.Where(x => x.Yazar.AdiSoyadi == TbYazarAdi.Text)
                .GroupBy(y => new { y.KitapTuru }, (key, liste) =>
                    {
                        return new
                        {
                            kitaplar =key.KitapTuru,
                            adet = liste.Count()
                        };
    
                    });
            LbSonuc.DataSource = kitaplaaar.ToList();
                


        }

        private void BtnKitapTurOrtalamaFiyat_Click(object sender, EventArgs e)
        {
            KitapTuru seciliKitapTuru = (KitapTuru)CbKitapTur.SelectedIndex;
            var kitapq = FakeDb.Kitaplar.Where(x => x.KitapTuru == seciliKitapTuru)
                .GroupBy(y =>y.KitapTuru, (key, liste) =>
                  {
                      return new
                      {
                          ort = liste.Average(x=> x.Fiyat)
                      };
                  });
            foreach (var item in kitapq)
            {
                MessageBox.Show(item.ort.ToString());
            }
            //Secili Kitap Turuna Ait Kitaplarin ortalama fiyatını bulun
        }

        private void BtnEnPahalıKitap_Click(object sender, EventArgs e)
        {
            // FakeDb'deki En Pahalı Kitabın satis fiyatını ve adını mbox'a yazdırın
            // var kitapq = FakeDb.Kitaplar.Where(x => x.KitapTuru == seciliKitapTuru)
            //  .GroupBy(y => y.KitapTuru, (key, liste) =>

            var enpahali = FakeDb.Kitaplar.Max(x => x.Fiyat);
            var kitapp = FakeDb.Kitaplar.FirstOrDefault(y => y.Fiyat == enpahali)
                .Adi;

            MessageBox.Show(kitapp + " " + enpahali);




        }

        private void BtnFiyatOrtalamaFazla_Click(object sender, EventArgs e)
        {
            // FakeDb'deki Fiyatı Ortalama Kitap Fiyatından Fazla olan Kitapları LbSonuc'ta listeleyin
            var enbuyuk = FakeDb.Kitaplar.Average(y => y.Fiyat);
            var sa = FakeDb.Kitaplar.Where(x => x.Fiyat > enbuyuk).Select(a => a.Adi);
            LbSonuc.DataSource = sa.ToList();
                
                
        }

        private void TbFiyatAralık_Click(object sender, EventArgs e)
        {
            // FakeDb'deki Fiyatı TbMin ile TbMax arasında olan Kitapları Fiyata göre azalan şekilde
            // LbSonuc'ta listeleyin
            //.OrderBy(a => a.KitapTuru);
            // var kitapciklar = FakeDb.Kitaplar.GroupBy(x => x.KitapTuru)
            //.Select(y => new
            // {
            //     KitapTuru = y.Key,
            //     Count = y.Count()
            // }).OrderBy(a => a.KitapTuru);

            //var enbuyuk = FakeDb.Kitaplar.Max(y => y.Fiyat);
            //var enkucuk = FakeDb.Kitaplar.Min(a => a.Fiyat);
            var sonuc = FakeDb.Kitaplar.Where(x => x.Fiyat >Convert.ToDouble(TbMin.Text)&& x.Fiyat < Convert.ToDouble(TbMax.Text))
                .Select(a => new { a.Adi, a.Fiyat }).OrderBy(s => s.Fiyat);
            LbSonuc.DataSource = sonuc.ToList();


        }

        private void BtnKısadanUzuna_Click(object sender, EventArgs e)
        {
            //Kitapları sayfa sayısına göre kısadan uzuna sıralayın,
            //kitapların isimlerini ve satış fiyatlarını LbSonuc'ta listeleyin

            //var uzun = FakeDb.Kitaplar.Max(x => x.SayfaSayisi);
            //var kisa = FakeDb.Kitaplar.Min(y => y.SayfaSayisi);
            var sayfacik = FakeDb.Kitaplar.Select(x => 
            new
            { x.Adi, x.Fiyat,x.SayfaSayisi }).OrderBy(y=> y.SayfaSayisi);
            LbSonuc.DataSource = sayfacik.ToList();
            



        }

        private void BtnYılSatis_Click(object sender, EventArgs e)
        {
            // Her Yıl kaç adet kitap satıldığını ve bu kitaplardan elde edilen geliri LbSonuc'ta listeleyin
         
            var fiyat = FakeDb.Kitaplar.Sum(x => x.Fiyat);
            var satilanlar = FakeDb.Satislar.GroupBy(y => y.SatisTarihi.Year,
                (key, liste) =>
               {
                   return new
                   {
                       key,
                       fiyat = liste.Sum(x => x.AlınanKitap.Fiyat)
                   };
               });
                
            LbSonuc.DataSource = satilanlar.ToList();

        }

        private void BtnKinKacKitap_Click(object sender, EventArgs e)
        {
            //Tüm kullanıcıların kaç kitap aldığını LbSonuc'ta listeleyin (KullanıcıAdi, KitapSayisi)

            var hepsi = FakeDb.Satislar
                .GroupBy(x => x.SatinAlanKullanici.KullaniciAdi, 
                (key, liste) =>
             {
                 return new
                 {
                     adi = key,
                     kitapSayisi = liste.Count()
                 };
             });

            LbSonuc.DataSource = hepsi.ToList();  



        }

        private void BtnAralikTurKitap_Click(object sender, EventArgs e)
        {
            //KitapTuru seciliKitapTuru = (KitapTuru)CbKitapTur.SelectedIndex;
            //var kitapq = FakeDb.Kitaplar.Where(x => x.KitapTuru == seciliKitapTuru)
            //    .GroupBy(y => y.KitapTuru, (key, liste) =>
            //    {
            //        return new
            //        {
            //            ort = liste.Average(x => x.Fiyat)
            //        };
            //    });
            //foreach (var item in kitapq)
            //{
            //    MessageBox.Show(item.ort.ToString());
            //}
            KitapTuru seciliKitapTuru = (KitapTuru)CbKitapTur.SelectedIndex;
            //Girilen seciliKitapTurun'deki (en ucuz) kitabın adi ve Yazarının adini mbox ile ekrana yazın
            var ucuz = FakeDb.Kitaplar.Min(x => x.Fiyat);
            var selam = FakeDb.Kitaplar.FirstOrDefault(x => x.KitapTuru == seciliKitapTuru && x.Fiyat <= ucuz);
            
            MessageBox.Show(selam.Yazar.AdiSoyadi + " , " + selam.Adi);



        }

        private void BtnKitapHediye_Click(object sender, EventArgs e)
        {
            //Tüm kullanıcıların  kaç tane hediye kitap aldığını LbSonuc'ta listeleyin (KullanıcıAdi, HediyeKitapSayisi)
            
            var hediye = FakeDb.Satislar.Where(y=> y.HediyeMi==true).GroupBy(x => x.SatinAlanKullanici.KullaniciAdi, (key, liste) =>
           {
               return new
               {
                   adi = key,
                   Hediye = liste.Count()
               };
           });
            
            LbSonuc.DataSource = hediye.ToList();


                


        }

        private void BtnKitapHediyeMi_Click(object sender, EventArgs e)
        {
            //TbKitapAdi'na adı girilen kitabın hediye edilip edilmediğini mbox  ile ekrana yazın

            var hediyemi = FakeDb.Satislar.Any
                (x => x.HediyeMi == true && x.AlınanKitap.Adi == TbKitapAdi.Text);
            MessageBox.Show(hediyemi.ToString());


        }

        private void BtnKitapHediyeEdilmeSayisi_Click(object sender, EventArgs e)
        {
            // TbKitapAdi'na adı girilen kitabın kaç adet hediye edildiğini mbox ile ekrana yazın

            var sa = FakeDb.Satislar.Where(y => y.HediyeMi == true).Count();
            MessageBox.Show(sa.ToString());


        }

        private void BtnYayinEviYazar_Click(object sender, EventArgs e)
        {
            //Hangi yayınevi hangi yazar'ın kaç adet kitabını başmıs LbSonuc'ta listeleyin (YayınEviAdı, YazarAdı, KitapAdedi)
        }

        private void BtnYazarKitapİlk_Click(object sender, EventArgs e)
        {
            //TbYazarAdi'na girilen Yazarın ilk basılan kitabının adını ve Basım tarihini mbox ile ekrana yazın
        }

        private void BtnYayinEviFiyat_Click(object sender, EventArgs e)
        {
            //Tüm Yayınevlerinin Toplam Sattığı kitap adedini ve Kaç adet kitap sattığını LbSonuc'ta listeleyin
        }
    }
}

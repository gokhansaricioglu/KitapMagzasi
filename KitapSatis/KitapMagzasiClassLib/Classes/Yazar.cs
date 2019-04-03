using System;

namespace KitapMagzasiClassLib.Classes
{
    public class Yazar
    {
        public Yazar(string adiSoyadi, DateTime dogumTarihi)
        {
            AdiSoyadi = adiSoyadi;
            DogumTarihi = dogumTarihi;
            YazarId = Guid.NewGuid().ToString();
        }

        public string YazarId { get; set; }
        public string AdiSoyadi { get; set; }
        public DateTime DogumTarihi { get; set; }

    }
}
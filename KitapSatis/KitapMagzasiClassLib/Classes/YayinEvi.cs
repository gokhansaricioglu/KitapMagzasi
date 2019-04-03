using System;

namespace KitapMagzasiClassLib.Classes
{
    public class YayinEvi
    {
        public YayinEvi(string yayinEviAdi)
        {
            YayinEviId = Guid.NewGuid().ToString();
            YayinEviAdi = yayinEviAdi;
        }

        public string YayinEviId { get; set; }
        public string YayinEviAdi { get; set; }
    }
}
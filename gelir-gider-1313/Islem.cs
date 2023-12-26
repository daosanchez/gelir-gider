using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gelir_gider_1313
{
    internal class Islem
    {
        public int Id { get; set; }
        public string Tanim { get; set; }
        public string Tur { get; set; }
        public DateTime Tarih { get; set; }
        public string Miktar { get; set; }
        public bool Gelir { get; set; }

        public Islem(int ıd, string tanim, string tur, DateTime tarih, string miktar, bool gelir)
        {
            Id = ıd;
            Tanim = tanim;
            Tur = tur;
            Tarih = tarih;
            Miktar = miktar;
            Gelir = gelir;
        }
    }
}

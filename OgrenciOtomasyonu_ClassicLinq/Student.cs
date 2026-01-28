using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu_ClassicLinq
{
    internal class Student
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public double N1 { get; set; }
        public double N2 { get; set; }
        public string Sinif { get; set; }

        public string TamAd
        {
            get { return Ad + " " + Soyad; }
        }

        public double Ortalama
        {
            get { return (N1 + N2) / 2; }
        }

        public int Yas
        {
            get 
            { 
                int yas = DateTime.Now.Year - DogumTarihi.Year;
                if (DogumTarihi.Date.AddYears(yas) > DateTime.Now) yas--;
                return yas; 
            }
        }

        public void Yazdir(int sira)
        {
            Console.WriteLine(sira + "- " + TamAd + " - Sınıf:" + Sinif + " - Ortalama: " + Ortalama);
        }
    }
}

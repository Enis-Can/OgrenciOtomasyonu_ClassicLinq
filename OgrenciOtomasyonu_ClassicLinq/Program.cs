// 1- Öğrenci Ekle
// 2- Öğrenci Listele
// 3- Öğrenci Sil
// 4- Silinen Öğrencileri Listele
// 5- Öğrencileri Sırala (isim, not, sınıf)
// 6- Öğrencilerin Yaş Ortalaması
// 7- En Yüksek Not Ortalaması Olan Öğrenci
// 8- Programdan Çık


// Yukarıdaki ekleme ve silme işlemleri hariç tüm işlemler Classic Linq yöntemi ile yapılacak.

using OgrenciOtomasyonu_ClassicLinq;

ConsoleKey key;


do
{
    Console.Clear();
    Console.WriteLine("ÖĞRENCİ OTOMASYONU");
    Console.WriteLine("------------------");
    Console.WriteLine("1- Öğrenci Ekle");
    Console.WriteLine("2- Öğrenci Listele");
    Console.WriteLine("3- Öğrenci Sil");
    Console.WriteLine("4- Silinen Öğrencileri Listele");
    Console.WriteLine("5- Öğrencileri Sırala (isim, not, sınıf)");
    Console.WriteLine("6- Öğrencilerin Yaş Ortalaması");
    Console.WriteLine("7- En Yüksek Not Ortalaması Olan Öğrenci");
    Console.WriteLine("8- Programdan Çık");
    Console.WriteLine();
    Console.Write("Lütfen bir işlem seçiniz: ");
    key = Console.ReadKey().Key;
    Menu.MenuOptions(key);
}
while (key!=ConsoleKey.NumPad8 && key!=ConsoleKey.D8);

Console.ReadKey();
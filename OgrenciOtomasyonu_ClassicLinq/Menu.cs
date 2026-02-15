using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu_ClassicLinq
{
    internal class Menu
    {
        static List<Student> students = new();
        static List<Student> deletedStudents = new();
        public static void MenuOptions(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    AddStudent("ÖĞRENCİ EKLE");
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    ListStudents("ÖĞRENCİ LİSTELE");
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    DeleteStudent("ÖĞRENCİ SİL");
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    ListDeleted("SİLİNEN ÖĞRENCİLERİ LİSTELE");
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    OrderStudents("ÖĞRENCİLERİ SIRALA");
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    AverageOld("ÖĞRENCİLERİN YAŞ ORTALAMASI");
                    break;
                case ConsoleKey.NumPad7:
                case ConsoleKey.D7:
                    HighestScore("EN YÜKSEK NOT ORTALAMASI OLAN ÖĞRENCİ");
                    break;
                case ConsoleKey.NumPad8:
                case ConsoleKey.D8:
                    break;
                    default:
                    ToMenu("Geçersiz seçim yaptınız.");
                    break;
            }
        }

        private static void HighestScore(string v)
        {
            Header(v);
            if (students.Any())
            {
                var orderedByScore = from s in students
                                 orderby s.Ortalama descending
                                 select s;
                Console.Write("En yüksek not ortalamasına sahip öğrenci: ");
                orderedByScore.First().Yazdir(1);
                ToMenu("En yüksek not ortalaması olan öğrenci listelendi.");
            }
            else
            {
                ToMenu("Not ortalaması hesaplanacak öğrenci bulunamadı.");
            }
        }

        private static void AverageOld(string v)
        {
            Header(v);
            if(students.Any())
            {
                var ages = from s in students select s.Yas;
                Console.WriteLine("Öğrencilerin yaş ortalaması: {0}", Math.Round(ages.Average(),2));
                ToMenu("Yaş ortalaması hesaplama işlemi tamamlandı.");
            }
            else
            {
                ToMenu("Yaş ortalaması hesaplanacak öğrenci bulunamadı.");
            }
        }

        private static void OrderStudents(string v)
        {
            Header(v);
            if(students.Any())
            {
                Console.WriteLine("1- İsme göre sırala");
                Console.WriteLine("2- Not ortalamasına göre sırala");
                Console.WriteLine("3- Sınıfa göre sırala");
                ConsoleKey key = Getter.GetConsoleKey("Lütfen bir sıralama kriteri seçiniz: ", ConsoleKey.NumPad1, ConsoleKey.D1, ConsoleKey.NumPad2, ConsoleKey.D2, ConsoleKey.NumPad3, ConsoleKey.D3);
                Console.WriteLine();
                if (key == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
                {
                    Console.WriteLine();
                    var orderedByName = from s in students
                                        orderby s.TamAd
                                        select s;
                    Lister.ListStudents(orderedByName);
                    ToMenu("İsme göre sıralama tamamlandı.");
                }
                else if(key == ConsoleKey.NumPad2 || key == ConsoleKey.D2)
                {
                    Console.WriteLine();
                    var orderedByScore = from s in students
                                         orderby s.Ortalama descending
                                         select s;
                    Lister.ListStudents(orderedByScore);
                    ToMenu("Not ortalamasına göre sıralama tamamlandı.");
                }
                else if(key == ConsoleKey.NumPad3 || key == ConsoleKey.D3)
                {
                    Console.WriteLine();
                    var orderedByClass = from s in students
                                         orderby s.Sinif
                                         select s;
                    Lister.ListStudents(orderedByClass);
                    ToMenu("Sınıfa göre sıralama tamamlandı.");
                }
            }
            else
            {
                ToMenu("Listelenecek öğrenci bulunamadı.");
            }
        }

        private static void ListDeleted(string v)
        {
            Header(v);
            if (deletedStudents.Any())
            {
                Lister.ListStudents(deletedStudents);
                Console.WriteLine("Toplam {0} öğrenci listelendi.", deletedStudents.Count);
                ToMenu("Listeleme işlemi tamamlandı.");
            }
            else
            {
                ToMenu("Listelenecek silinmiş öğrenci bulunamadı.");
            }
        }

        private static void DeleteStudent(string v)
        {
            Header(v);
            if (students.Any())
            {
                Lister.ListStudents(students);
                int index = Getter.GetInt("Silinecek öğrencinin ID numarasını giriniz: ", 1, students.Count) - 1;
                Student deletedStudent = students[index];
                Console.Write("{0} adlı öğrenciyi silmek istediğinize emin misiniz?(e) ",deletedStudent.Ad);
                if(Console.ReadKey().Key == ConsoleKey.E)
                {
                    students.RemoveAt(index);
                    deletedStudents.Add(deletedStudent);
                    ToMenu("Öğrenci başarıyla silindi.");
                }
                else
                {
                    ToMenu("Silme işlemi iptal edildi.");
                }
            }
            else
            {
                ToMenu("Silinecek öğrenci bulunamadı.");
            }
        }

        private static void ListStudents(string v)
        {
            Header(v);
            if (students.Any())
            {
                Lister.ListStudents(students);
                Console.WriteLine("Toplam {0} öğrenci listelendi.", students.Count);
                ToMenu("Listeleme işlemi tamamlandı.");
            }
            else
            {
                ToMenu("Listelenecek öğrenci bulunamadı.");
            }
        }

        private static void AddStudent(string v)
        {
            Header(v);
            Student student = new Student()
            {
                Ad = Getter.GetString("Ad: ", 2, 20),
                Soyad = Getter.GetString("Soyad: ", 2, 20),
                DogumTarihi = Getter.GetDateTime("Doğum Tarihi (gg.aa.yyyy): ", DateTime.Now.AddYears(-40), DateTime.Now.AddYears(-16)),
                Sinif = Getter.GetString("Sınıf: ", 1, 10),
                N1 = Getter.GetDouble("1. Not: ", 0, 100),
                N2 = Getter.GetDouble("2. Not: ", 0, 100)
            };
            students.Add(student);
            ToMenu("Öğrenci başarıyla eklendi.");
        }

        private static void ToMenu(string v)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine("Ana menüye dönmek için bir tuşa basınız.");
            Console.ReadKey();
        }

        private static void Header(string v)
        {
            Console.Clear();
            Console.WriteLine(v);
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}

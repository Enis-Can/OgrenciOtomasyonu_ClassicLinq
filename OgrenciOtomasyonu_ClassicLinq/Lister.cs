using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu_ClassicLinq
{
    internal class Lister
    {
        public static void ListStudents(List<Student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                students[i].Yazdir(i + 1);
            }
        }
        public static void ListStudents(IOrderedEnumerable<Student> students)
        {
            int index = 1;
            foreach (var student in students)
            {
                student.Yazdir(index);
                index++;
            }
        }
    }
}

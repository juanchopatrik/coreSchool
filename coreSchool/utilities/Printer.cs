using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreSchool.utilities
{
    public static class Printer
    {

        public static void DibujarLinea(int pTam = 10)
        {
            string linea = "".PadLeft(pTam, '=');
            Console.WriteLine(linea);
        }

        public static void WriteTitle(string title)
        {
            var tamaño = title.Length + 4;
            DibujarLinea(tamaño);
            Console.WriteLine($"| {title} |");
            DibujarLinea(tamaño);
        }
    }
}

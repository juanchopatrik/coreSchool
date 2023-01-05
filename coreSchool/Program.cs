using coreSchool.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academic", 2012);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogota";
            escuela.TipoEscuela = TiposEscuela.Preescolar;

            Console.WriteLine(escuela);
            
            Console.WriteLine(escuela.Nombre + " " + escuela.AñoDeCreacion);
        }
    }
}

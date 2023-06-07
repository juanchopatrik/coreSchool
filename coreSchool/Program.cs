using coreSchool.App;
using coreSchool.entidades;
using coreSchool.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace coreSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            
            engine.Inicializar();

            ImprimirCursos(engine.escuela);

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas poliformismo");

            var alumntoTest = new Alumno { Nombre = "Claire Underwood"};

            ObjetoEscuelaBase ob = alumntoTest;
        }

        private static void ImprimirCursos(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuala");
            
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, id {curso.UniqueId}");
                }
            }
        }
    }
}

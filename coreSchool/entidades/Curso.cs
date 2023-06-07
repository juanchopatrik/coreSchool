using coreSchool.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreSchool.entidades
{
    public  class Curso : ObjetoEscuelaBase, ILugar
    {
        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public string Direccion { get; set; }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Curso");
            Console.WriteLine($"Curso  {Nombre} Limpio");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreSchool.entidades
{
    internal class Escuela
    {
        public string Nombre { get; set; }

        public string Pais { get; set; }

        public int AñoDeCreacion { get; set; }

        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }
        public Escuela(string nombre, int añoDeCreacion)
        {
            Nombre = nombre;
            AñoDeCreacion = añoDeCreacion;
        }

        public override string ToString()
        {
            return $"Nombre : {Nombre}, Tipo: {TipoEscuela},  Pais: {Pais}, Ciudad: {Ciudad}";
        }
    }
}

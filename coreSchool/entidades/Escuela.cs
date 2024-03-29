﻿using coreSchool.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreSchool.entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {

        public string Pais { get; set; }

        public int AñoDeCreacion { get; set; }

        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }
        public string Direccion { get; set; }

        public Escuela(string nombre
            , int añoDeCreacion
            , TiposEscuela tipoEscuela
            , string pais = ""
            , string ciudad = "") : this(nombre, añoDeCreacion)
        {
            TipoEscuela = tipoEscuela;
            Pais = pais;
            Ciudad = ciudad;
        }

        public Escuela(string nombre, int añoDeCreacion) => (Nombre, AñoDeCreacion) = (nombre, añoDeCreacion);

        public override string ToString()
        {
            return $"Nombre : {Nombre}, Tipo: {TipoEscuela}" +
                $", {System.Environment.NewLine} Pais: {Pais}" +
                $", Ciudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela");
            Cursos.ForEach(curso => curso.LimpiarLugar());
            Printer.WriteTitle($"Escuela {Nombre} Limpia");
        }
    }
}

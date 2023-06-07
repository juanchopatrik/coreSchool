﻿using coreSchool.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace coreSchool.App
{
    public class EscuelaEngine
    {

        public Escuela escuela { get; set; }


        public void Inicializar()
        {
            var escuela = new Escuela("Platzi Academic", 2012);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogota";

            CargarCursos(escuela);

            CargarAsignaturas(escuela);

        }

        private float NotaAleatoria()
        {
            Random rnd = new Random();
            return (float)rnd.NextDouble() * 5;
        }

        public List<Evaluacion> CreacionEvaluaciones()
        {
            var evaluationList =   new List<Evaluacion>()
            {
                new Evaluacion{Nombre = "taller 1"},
                new Evaluacion{Nombre = "taller 2"},
                new Evaluacion{Nombre = "taller 3"},
                new Evaluacion{Nombre = "examen 1"},
                new Evaluacion{Nombre = "examen 2"},
            };

            evaluationList.ForEach(p => Console.WriteLine(p.Nombre));

            return evaluationList;
        }


        private void CargarAsignaturas(Escuela pEscuela)
        {
            foreach (var curso in pEscuela.Cursos)
            {
                List<Asignatura> listaAsignatura = new List<Asignatura>()
                {
                        new Asignatura{Nombre = "Matematicas"},
                        new Asignatura{Nombre = "Educacion Fisica"},
                        new Asignatura{Nombre = "Castellano"},
                        new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignatura;
            }
        }

        private static List<Alumno> GenerarAlumnosAlzar(int pCantidad)
        {
            string[] nombre1 = { "Alba", "Felipe", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolai" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy(alum => alum.UniqueId).Take(pCantidad).ToList();
        }

        private void CargarCursos(Escuela pEscuela)
        {
            pEscuela.Cursos = new List<Curso>()
            {
                new Curso() {Nombre = "101", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
                new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
            };

            Random rnd = new Random();

            foreach (var c in pEscuela.Cursos)
            {
                int pCantidadRamdom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlzar(pCantidadRamdom);
            }
        }
    }
}
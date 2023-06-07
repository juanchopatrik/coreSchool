using coreSchool.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace coreSchool.App
{
    public sealed class EscuelaEngine
    {

        public Escuela escuela { get; set; }

        public EscuelaEngine()
        {
        }


        public void Inicializar()
        {
            escuela = new Escuela("Platzi Academic", 2012);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogota";

            CargarCursos();

            CargarAsignaturas();

            CargarEvaluaciones();

        }

        public List<ObjetoEscuelaBase> GetObjetoEscuelas()
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(escuela);
            listaObj.AddRange(escuela.Cursos);

            escuela.Cursos.ForEach(curso =>
            {
                listaObj.AddRange(curso.Asignaturas);

                listaObj.AddRange(curso.Alumnos);

                curso.Alumnos.ForEach(alumno =>
                {
                    listaObj.AddRange(alumno.evaluaciones);
                });
            });

            return listaObj;
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

        private void CargarAsignaturas()
        {
            foreach (var curso in escuela.Cursos)
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

        private void CargarCursos()
        {
            escuela.Cursos = new List<Curso>()
            {
                new Curso() {Nombre = "101", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
                new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
            };

            Random rnd = new Random();

            foreach (var c in escuela.Cursos)
            {
                int pCantidadRamdom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlzar(pCantidadRamdom);
            }
        }

        private void CargarEvaluaciones()
        {
            foreach (var curso in escuela.Cursos)
            {
                foreach (var alumno in curso.Alumnos)
                {
                    foreach (var asignatura in curso.Asignaturas)
                    {
                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion()
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno,
                            };
                            alumno.evaluaciones.Add(ev);
                        }
                    }
                }
            }

        }
    }
}

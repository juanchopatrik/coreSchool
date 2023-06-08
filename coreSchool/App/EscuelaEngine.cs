using coreSchool.entidades;
using coreSchool.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Permissions;
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

        public void ImprimirDiccionario(Dictionary<LlavesDiccionario
            , IEnumerable<ObjetoEscuelaBase>> dic, bool imprEval = false)
        {

            foreach (var objdic in dic)
            {
                Printer.WriteTitle(objdic.Key.ToString());
                foreach (var val in  objdic.Value)
                {
                    switch (objdic.Key)
                    {
                        case LlavesDiccionario.EVALUACIONES:
                            if (imprEval)
                                Console.WriteLine(val);
                            break;
                        case LlavesDiccionario.ESCUELA:
                            Console.WriteLine("Escuela: " + val);
                            break;
                        case LlavesDiccionario.ALUMNOS:
                            Console.WriteLine("Alumno: " + val.Nombre);
                            break;
                        case LlavesDiccionario.CURSOS:
                            var curtmp = val as Curso;
                            if (curtmp != null)
                            {
                                int count = curtmp.Alumnos.Count;
                                Console.WriteLine("Curso: " + val.Nombre + " Cantidad Alumnos: " + count);
                            }
                            break;
                        default:
                            Console.WriteLine(val);
                            break;

                    }
                }

            }

        }
        public Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlavesDiccionario.ESCUELA, new[] { escuela });
            diccionario.Add(LlavesDiccionario.CURSOS, escuela.Cursos.Cast<ObjetoEscuelaBase>());

            var listatmp = new List<Evaluacion>();
            var listatmpas = new List<Asignatura>();
            var listatmpal = new List<Alumno>();

            foreach (var cur in escuela.Cursos)
            {
                listatmpas.AddRange(cur.Asignaturas);
                listatmpal.AddRange(cur.Alumnos);

                foreach (var alum in cur.Alumnos)
                {
                    listatmp.AddRange(alum.evaluaciones);
                }

            }
            diccionario.Add(LlavesDiccionario.EVALUACIONES,
                                    listatmp.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlavesDiccionario.ASIGNATURAS,
                                    listatmpas.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlavesDiccionario.ALUMNOS,
                                    listatmpal.Cast<ObjetoEscuelaBase>());
            return diccionario;
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

        #region sobrecarga

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            return GetObjetoEscuelas(
            out int dummy,
            out dummy,
            out dummy,
            out dummy
            );
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            return GetObjetoEscuelas(
            out conteoEvaluaciones,
            out int dummy,
            out dummy,
            out dummy
            );
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
            out int conteoEvaluaciones,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            return GetObjetoEscuelas(
            out conteoEvaluaciones,
            out conteoCursos,
            out int dummy,
            out dummy
            );
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            return GetObjetoEscuelas(
            out conteoEvaluaciones,
            out conteoCursos,
            out conteoAsignaturas,
            out int dummy
            );
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelas(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {

            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = 0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(escuela);

            if (traeCursos)
                listaObj.AddRange(escuela.Cursos);
            conteoCursos = escuela.Cursos.Count;

            foreach (var curso in escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;

                if (traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);


                if (traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        conteoEvaluaciones += alumno.evaluaciones.Count;
                        listaObj.AddRange(alumno.evaluaciones);
                    }
                }
            }

            return listaObj.AsReadOnly();
        }
        #endregion

        #region Metodos de Carga

        public List<Evaluacion> CreacionEvaluaciones()
        {
            var evaluationList = new List<Evaluacion>()
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
                                Nota = (float)Math.Round((5 * rnd.NextDouble()),2),
                                Alumno = alumno,
                            };
                            alumno.evaluaciones.Add(ev);
                        }
                    }
                }
            }

        }

        #endregion
    }
}

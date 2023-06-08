using coreSchool.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreSchool.App
{
    public class Reporteador
    {
        Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlavesDiccionario
            , IEnumerable<ObjetoEscuelaBase>> dicObEsc)
        {
            if (dicObEsc == null)
                throw new ArgumentNullException(nameof(dicObEsc));

            _diccionario = dicObEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlavesDiccionario.EVALUACIONES
                , out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            else
            {
                return new List<Evaluacion>();
            }
        }
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy );
        }

        public IEnumerable<string> GetListaAsignaturas( 
            out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return listaEvaluaciones.Select(pEvaluacion =>
            pEvaluacion.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluaXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;

                dictaRta.Add(asig, evalsAsig);
            }
            return dictaRta;
        }
    }

}

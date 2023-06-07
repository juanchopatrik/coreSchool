using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreSchool.entidades
{
    public class Alumno : ObjetoEscuelaBase
    {
        public List<Evaluacion> evaluaciones { get; set; } = new List<Evaluacion>();
        
    }
}

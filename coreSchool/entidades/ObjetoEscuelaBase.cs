﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreSchool.entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId { get; private  set; }

        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString(); 
        }

        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }
}

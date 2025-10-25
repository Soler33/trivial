using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialCoches.Models
{
    public class Pregunta
    {
        public string Imagen { get; set; }
        public string RespuestaCorrecta { get; set; }
        public List<string> Opciones { get; set; }

        public Pregunta()
        {
            Opciones = new List<string>();
        }
    }
}

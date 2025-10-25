using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialCoches.Models
{
    public class Marca
    {
        public string Nombre { get; set; }
        public string ImagenCoche { get; set; }
        public string ImagenLogo { get; set; }

        public Marca(string nombre)
        {
            Nombre = nombre;
            ImagenCoche = $"{nombre.ToLower()}.jpg";
            ImagenLogo = $"{nombre.ToLower()}_logo.jpg";
        }
    }
}

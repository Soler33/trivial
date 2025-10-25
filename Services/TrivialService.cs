using TrivialCoches.Models;

namespace TrivialCoches.Services
{
    public class TrivialService
    {
        private List<Marca> marcas;
        private Random random;

        public TrivialService()
        {
            random = new Random();
            InicializarMarcas();
        }

        private void InicializarMarcas()
        {
            marcas = new List<Marca>
            {
                new Marca("Audi"),
                new Marca("BMW"),
                new Marca("Mercedes"),
                new Marca("Ferrari"),
                new Marca("Porsche"),
                new Marca("Toyota"),
                new Marca("Honda"),
                new Marca("Ford"),
                new Marca("Chevrolet"),
                new Marca("Volkswagen"),
                new Marca("Nissan"),
                new Marca("Mazda"),
                new Marca("Lamborghini"),
                new Marca("Bugatti"),
                new Marca("Tesla"),
                new Marca("Hyundai")
            };
        }

        public List<Pregunta> GenerarPreguntasCoches()
        {
            return GenerarPreguntas(true);
        }

        public List<Pregunta> GenerarPreguntasLogos()
        {
            return GenerarPreguntas(false);
        }

        private List<Pregunta> GenerarPreguntas(bool usarImagenCoche)
        {
            // Seleccionar 7 marcas aleatorias
            var marcasSeleccionadas = marcas.OrderBy(x => random.Next()).Take(7).ToList();
            var preguntas = new List<Pregunta>();

            foreach (var marcaCorrecta in marcasSeleccionadas)
            {
                var pregunta = new Pregunta
                {
                    Imagen = usarImagenCoche ? marcaCorrecta.ImagenCoche : marcaCorrecta.ImagenLogo,
                    RespuestaCorrecta = marcaCorrecta.Nombre
                };

                // Generar 3 opciones incorrectas
                var opcionesIncorrectas = marcas
                    .Where(m => m.Nombre != marcaCorrecta.Nombre)
                    .OrderBy(x => random.Next())
                    .Take(3)
                    .Select(m => m.Nombre)
                    .ToList();

                // Combinar respuesta correcta con incorrectas y mezclar
                pregunta.Opciones = opcionesIncorrectas.Concat(new[] { marcaCorrecta.Nombre })
                    .OrderBy(x => random.Next())
                    .ToList();

                preguntas.Add(pregunta);
            }

            return preguntas;
        }
    }
}
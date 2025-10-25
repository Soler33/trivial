using TrivialCoches.Models;
using TrivialCoches.Services;

namespace TrivialCoches
{
    public partial class LogosPage : ContentPage
    {
        private TrivialService trivialService;
        private List<Pregunta> preguntas;
        private int preguntaActual;
        private int puntuacion;
        private List<Button> botones;

        public LogosPage()
        {
            InitializeComponent();
            trivialService = new TrivialService();
            botones = new List<Button> { Opcion1, Opcion2, Opcion3, Opcion4 };
            IniciarTrivial();
        }

        private void IniciarTrivial()
        {
            preguntas = trivialService.GenerarPreguntasLogos();
            preguntaActual = 0;
            puntuacion = 0;
            MostrarPregunta();
        }

        private void MostrarPregunta()
        {
            if (preguntaActual >= preguntas.Count)
            {
                MostrarResultadoFinal();
                return;
            }

            var pregunta = preguntas[preguntaActual];

            // Actualizar progreso y puntuación
            ProgresoLabel.Text = $"Pregunta {preguntaActual + 1} de {preguntas.Count}";
            PuntuacionLabel.Text = $"Puntuación: {puntuacion} / {preguntas.Count}";

            // Actualizar imagen del logo
            ImagenLogo.Source = pregunta.Imagen;

            // Actualizar opciones
            for (int i = 0; i < botones.Count; i++)
            {
                botones[i].Text = pregunta.Opciones[i];
                botones[i].BackgroundColor = Color.FromArgb("#FF6B35");
                botones[i].IsEnabled = true;
            }
        }

        private async void OnOpcionClicked(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            var respuestaSeleccionada = boton.Text;
            var pregunta = preguntas[preguntaActual];

            // Deshabilitar todos los botones
            foreach (var btn in botones)
            {
                btn.IsEnabled = false;
            }

            // Verificar respuesta
            if (respuestaSeleccionada == pregunta.RespuestaCorrecta)
            {
                boton.BackgroundColor = Color.FromArgb("#4CAF50"); // Verde
                puntuacion++;
                await DisplayAlert("Correcto!", $"Es {pregunta.RespuestaCorrecta}", "Siguiente");
            }
            else
            {
                boton.BackgroundColor = Color.FromArgb("#F44336"); // Rojo

                // Mostrar la respuesta correcta en verde
                foreach (var btn in botones)
                {
                    if (btn.Text == pregunta.RespuestaCorrecta)
                    {
                        btn.BackgroundColor = Color.FromArgb("#4CAF50");
                        break;
                    }
                }

                await DisplayAlert("Incorrecto", $"La respuesta correcta era: {pregunta.RespuestaCorrecta}", "Siguiente");
            }

            // Pasar a la siguiente pregunta
            preguntaActual++;
            MostrarPregunta();
        }

        private async void MostrarResultadoFinal()
        {
            string mensaje;
            string emoji;

            if (puntuacion == preguntas.Count)
            {
                mensaje = "Eres mu güeno";
            }
            else if (puntuacion >= preguntas.Count * 0.7)
            {
                mensaje = "Vas mejorando";
            }
            else if (puntuacion >= preguntas.Count * 0.4)
            {
                mensaje = "Bastante mediocre";
            }
            else
            {
                mensaje = "No sabes nada";
            }

            bool volverAJugar = await DisplayAlert(
                "Trivial Completado",
                $"{mensaje}\n\nPuntuación final: {puntuacion} / {preguntas.Count}",
                "Volver a jugar",
                "Menú principal"
            );

            if (volverAJugar)
            {
                IniciarTrivial();
            }
            else
            {
                await Navigation.PopAsync();
            }
        }
    }
}
namespace TrivialCoches
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCochesClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CochesPage());
        }

        private void OnLogosClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LogosPage());
        }
    }
}
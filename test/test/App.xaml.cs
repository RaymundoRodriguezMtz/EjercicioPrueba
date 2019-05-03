using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using test.Vistas;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainViewModel.ObtenerInstancia().ListaView = new ListaPersonasViewModel();
            this.MainPage = new ListaPersonasPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

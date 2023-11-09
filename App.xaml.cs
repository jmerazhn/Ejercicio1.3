using Ejercicio1._3.Views;

namespace Ejercicio1._3
{
    public partial class App : Application
    {

        static Controllers.DatosDB dbdatos = new Controllers.DatosDB();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Principal());
        }
    }
}
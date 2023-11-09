using Ejercicio1._3.Views;

namespace Ejercicio1._3
{
    public partial class App : Application
    {

        static Controllers.DatosDB dbdatos;

        public static Controllers.DatosDB DBdatos
        {
            get
            {
                if (dbdatos == null)
                {
                    //var PathApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var PathApp = FileSystem.AppDataDirectory;
                    var DBName = Models.Config.DBName;
                    var PathFull = Path.Combine(PathApp, DBName);


                    dbdatos = new Controllers.DatosDB(PathFull);
                }
                return dbdatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Datos());
        }
    }
}
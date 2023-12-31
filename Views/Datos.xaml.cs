using Ejercicio1._3.Controllers;

namespace Ejercicio1._3.Views;

public partial class Datos : ContentPage
{
    DatosDB db=new DatosDB();
	public Datos()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var data = new Models.Datos
        {
            Nombres = nombre.Text,
            Apellidos = apellidos.Text,
            Edad = edad.Text,
            Correo = correo.Text,
            Direccion = direccion.Text
        };

        if (await db.StoreDatos(data) > 0)
        {
            await DisplayAlert("Aviso", "Ingresado", "Ok");
            await Navigation.PushAsync(new Views.Principal());
        }
        else
        {
            await DisplayAlert("Aviso", "No Ingresado", "Ok");
        }


    }
}
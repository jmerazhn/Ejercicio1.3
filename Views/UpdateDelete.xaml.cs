using Ejercicio1._3.Controllers;

namespace Ejercicio1._3.Views;

public partial class UpdateDelete : ContentPage
{
    DatosDB db = new DatosDB();
	public UpdateDelete()
	{
		InitializeComponent();
	}

    private async void btnactualizar_Clicked(object sender, EventArgs e)
    {
        var data = new Models.Datos
        {
            Id = Int32.Parse(id.Text),
            Nombres = nombre.Text,
            Apellidos = apellidos.Text,
            Edad = edad.Text,
            Correo = correo.Text,
            Direccion = direccion.Text
        };

        if (await db.StoreDatos(data) > 0)
        {
            await DisplayAlert("Alerta", "Datos actualizados", "Ok");

            id.Text = "";
            nombre.Text = "";
            apellidos.Text = "";
            edad.Text = "";
            correo.Text = "";
            direccion.Text = "";

            await Navigation.PushAsync(new Views.Principal());
        }
        else
        {
            await DisplayAlert("Error", "No se pudo actualizar", "Ok");
        }
    }

    private async void btneliminar_Clicked(object sender, EventArgs e)
    {
        OnAlertYesNoClicked(sender, e);
    }

    async void OnAlertYesNoClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Alerta", "Eliminar Datos?", "Si", "No");

        if (answer == true)
        {
            var data = new Models.Datos
            {
                Id = Int32.Parse(id.Text)
            };

            if (await db.DeleteDatos(data) > 0)
            {
                await DisplayAlert("Alerta", "Datos eliminados", "Ok");

                id.Text = "";
                nombre.Text = "";
                apellidos.Text = "";
                edad.Text = "";
                correo.Text = "";
                direccion.Text = "";

                await Navigation.PushAsync(new Views.Principal());
            }
            else
            {
                await DisplayAlert("Error", "No se puede eliminar", "Ok");
            }

        }
    }
}
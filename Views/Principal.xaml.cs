using Ejercicio1._3.Controllers;

namespace Ejercicio1._3.Views;

public partial class Principal : ContentPage
{

    SQLiteDbContext db;
	public Principal()
	{
		InitializeComponent();
	}

    private void listadatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var elemento = e.CurrentSelection.FirstOrDefault() as Models.Datos;

        if (elemento != null)
        {
            Navigation.PushAsync(new UpdateDelete
            {
                BindingContext = elemento
            });
        }

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        

        listadatos.ItemsSource = await App.DBdatos.ListaDatos();
    }

    private async void toolagrega_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.Datos());

    }
}
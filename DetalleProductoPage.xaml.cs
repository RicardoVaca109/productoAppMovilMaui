using productoApp.Models;

namespace productoApp;

public partial class DetalleProductoPage : ContentPage
{
	
	public DetalleProductoPage(Producto producto)
	{
        NombreProducto.Text = producto.Nombre;
		Descripcion.Text = producto.Descripcion;
		CtdenStock.Text = producto.CtdenStock.ToString();

        InitializeComponent();
	}

	private async void OnClickVolver(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}
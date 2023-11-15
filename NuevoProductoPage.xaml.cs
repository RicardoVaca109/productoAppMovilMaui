using CommunityToolkit.Maui.Core;
using productoApp.Models;

namespace productoApp;

public partial class NuevoProducto : ContentPage
{
	public NuevoProducto()
	{
		InitializeComponent();
	}
    private async void OnClickGuardarNuevoProducto(object sender, EventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Se Guardo el Producto", ToastDuration.Short, 14);
        await toast.Show();
        Producto producto = new Producto
        {
            ProductoId = 0,
            Nombre = Nombre.Text,
            Descripcion = Descripcion.Text,
            CtdenStock = Int32.Parse(CtdenStock.Text),
            Precio = float.Parse(Precio.Text)
        };
        Utils.Utils.ListaProductos.Add(producto);
        await Navigation.PopAsync();
    }
}
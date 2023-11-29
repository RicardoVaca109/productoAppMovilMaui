using productoApp.Models;
using productoApp.Services;

namespace productoApp;

public partial class DetalleProductoPage : ContentPage
{
    private Producto _producto;
    private readonly APIService _APIService;

    public DetalleProductoPage(APIService apiservice)
	{
        InitializeComponent();
        _APIService = apiservice;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        Nombre.Text = _producto.Nombre;
        Descripcion.Text = _producto.Descripcion;
        CtdenStock.Text = _producto.CtdenStock.ToString();
        Precio.Text = _producto.Precio.ToString();

    }
    private async void ClickEliminarProducto(object sender, EventArgs e)
    {
        //Utils.Utils.ListaProductos.Remove(_producto);
        await _APIService.DeleteProducto(_producto.ProductoId);
        await Navigation.PopAsync();
    }

    private async void ClickEditarProducto(object sender, EventArgs e)
    {
        //var toast = CommunityToolkit.Maui.Alerts.Toast.Make(_producto.Nombre, ToastDuration.Short, 14);
        //await toast.Show();
        await Navigation.PushAsync(new NuevoProducto(_APIService)
        {

            BindingContext = _producto
        });
        
    }

}
using productoApp.Models;

namespace productoApp;

public partial class DetalleProductoPage : ContentPage
{
    private Producto _producto;
	public DetalleProductoPage()
	{
        InitializeComponent();
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
        Utils.Utils.ListaProductos.Remove(_producto);
        await Navigation.PopAsync();
    }

    private async void ClickEditarProducto(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new NuevoProducto()
        {

            BindingContext = _producto
        });
        
    }

}
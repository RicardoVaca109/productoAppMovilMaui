using CommunityToolkit.Maui.Core;
using productoApp.Models;

namespace productoApp;

public partial class NuevoProducto : ContentPage
{
    private Producto _producto;
    public NuevoProducto()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        if( _producto != null )
        {
            Nombre.Text = _producto.Nombre;
            Descripcion.Text = _producto.Descripcion;   
            CtdenStock.Text=_producto.CtdenStock.ToString();
            Precio.Text = _producto.Precio.ToString();

        }
    }
    private async void OnClickGuardarNuevoProducto(object sender, EventArgs e)
    {
        if ( _producto != null )
        {

            _producto.Nombre = Nombre.Text;
            _producto.Descripcion = Nombre.Text;
            _producto.CtdenStock = Int32.Parse(CtdenStock.Text);
            _producto.Precio = float.Parse(Precio.Text);    

        }
        int id = Utils.Utils.ListaProductos.Count + 1;
        Utils.Utils.ListaProductos.Add(new Producto
        {
            ProductoId = id,
            Nombre = Nombre.Text,
            Descripcion = Descripcion.Text,
            CtdenStock = Int32.Parse(CtdenStock.Text),
            Precio = float.Parse(Precio.Text)
        }
        );
       
    }
}
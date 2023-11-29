using CommunityToolkit.Maui.Core;
using productoApp.Models;
using productoApp.Services;

namespace productoApp;

public partial class NuevoProducto : ContentPage
{
    private Producto _producto;
    private readonly APIService _APIService;
    public NuevoProducto(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
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
            await _APIService.PutProducto(_producto.ProductoId, _producto);

        }
        else
        {
            int id = Utils.Utils.ListaProductos.Count + 1;
            Producto producto = new Producto
            {
                ProductoId = id,
                Nombre = Nombre.Text,
                Descripcion = Descripcion.Text,
                CtdenStock =Int32.Parse(CtdenStock.Text),
                Precio=float.Parse(Precio.Text),
            };
            await _APIService.PostProducto(producto);

         }
        await Navigation.PopAsync();
        /*int id = Utils.Utils.ListaProductos.Count + 1;
        Utils.Utils.ListaProductos.Add(new Producto
        {
            ProductoId = id,
            Nombre = Nombre.Text,
            Descripcion = Descripcion.Text,
            CtdenStock = Int32.Parse(CtdenStock.Text),
            Precio = float.Parse(Precio.Text)
        }
        );*/

    }
    }
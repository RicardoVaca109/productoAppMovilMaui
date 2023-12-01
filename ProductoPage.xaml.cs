//using Android.Widget;
using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
//using CommunityToolkit.Maui.Core;
//using CommunityToolkit.Maui.Alerts;
using productoApp.Models;
using System.Collections.ObjectModel;
using productoApp.Services;
using CommunityToolkit.Maui.Core;

namespace productoApp;

public partial class ProductoPage : ContentPage
{
    ObservableCollection<Producto> products;
    APIService _APIService;
    public ProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
		
	}
    protected async override  void OnAppearing()
    {
        base.OnAppearing();
        List<Producto> ListaProducts = await _APIService.GetProducto();
        products= new ObservableCollection<Producto>(Utils.Utils.ListaProductos);
        ListaProductos.ItemsSource = products;
    }
    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en nuevo producto", ToastDuration.Short, 14);
        await toast.Show();
        await Navigation.PushAsync(new NuevoProducto());

    }
    private async void OnClickedShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushAsync(new DetalleProductoPage()
        {
            BindingContext = producto,
        });
    }
    private async void OnClickedEliminarProducto(object sender, SelectedItemChangedEventArgs e)
    {

    }

}

//using Android.Widget;
using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
//using CommunityToolkit.Maui.Core;
//using CommunityToolkit.Maui.Alerts;
using productoApp.Models;
using System.Collections.ObjectModel;
using productoApp.Services;

namespace productoApp;

public partial class ProductoPage : ContentPage
{
    private readonly APIService _APIService;
   
    ObservableCollection<Producto> products;
    
    public ProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
		
	}
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<Producto> ListaProducts = await _APIService.GetProductos();
        products= new ObservableCollection<Producto>(ListaProducts);
        ListaProductos.ItemsSource = products;
    }
    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {
        //var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en nuevo producto", ToastDuration.Short, 14);
        //await toast.Show();
        await Navigation.PushAsync(new NuevoProducto(_APIService));

    }
    private async void OnClickedShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushAsync(new DetalleProductoPage(_APIService)
        {
            BindingContext = producto,
        });
    }
}

//using Android.Widget;
using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using productoApp.Models;
using System.Collections.ObjectModel;

namespace productoApp;

public partial class ProductoPage : ContentPage
{
	public ProductoPage()
	{
		InitializeComponent();
		
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var producto = new ObservableCollection<Producto>(Utils.Utils.ListaProductos);
        ListaProductos.ItemsSource = producto;
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
    }
}

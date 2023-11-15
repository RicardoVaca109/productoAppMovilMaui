//using Android.Widget;
using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
namespace productoApp;

public partial class ProductoPage : ContentPage
{
	public ProductoPage()
	{
		InitializeComponent();
		ListaProductos.ItemsSource = Utils.Utils.ListaProductos;
	}

	private async void OnClickNuevoProducto(object sender, EventArgs e)
	{
		var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en nuevo producto", ToastDuration.Short, 14);
        //await Navigation.PushAsync(NuevoProducto());
        await toast.Show();
		
	}
}

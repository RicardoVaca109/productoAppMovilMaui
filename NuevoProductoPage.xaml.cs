using CommunityToolkit.Maui.Core;
using productoApp.Models;
using productoApp.Services;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace productoApp
{
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
            if (_producto != null)
            {
                Nombre.Text = _producto.Nombre;
                Descripcion.Text = _producto.Descripcion;
                CtdenStock.Text = _producto.CtdenStock.ToString();
                Precio.Text = _producto.Precio.ToString();
            }
        }

        private async void OnClickGuardarNuevoProducto(object sender, EventArgs e)
        {
            try
            {
                if (_producto != null)
                {
                    _producto.Nombre = Nombre.Text;
                    _producto.Descripcion = Descripcion.Text;
                    _producto.CtdenStock = int.Parse(CtdenStock.Text);
                    _producto.Precio = float.Parse(Precio.Text);
                    
                    await _APIService.PutProducto(_producto.ProductoId, _producto);
                }
                else
                {
                    Producto nuevoProducto = new Producto
                    {
                        Nombre = Nombre.Text,
                        Descripcion = Descripcion.Text,
                        CtdenStock = int.Parse(CtdenStock.Text),
                        Precio = float.Parse(Precio.Text),
                        ProveedorId = int.Parse(ProveedorId.Text)
                    };

                    // Agrega a la lista local 
                    Utils.Utils.ListaProductos.Add(nuevoProducto);

                    // Envia la solicitud al servicio web
                    await _APIService.PostProducto(nuevoProducto);
                }

                // Navegar hacia atrás después de realizar las operaciones
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                // Manejar la excepción, mostrar mensaje al usuario, realizar el registro, etc.
                Console.WriteLine($"Error al guardar el producto: {ex.Message}");
            }
        }

        private void OnCantidadChanged(object sender, TextChangedEventArgs e)
        {
            if (!e.NewTextValue.All(char.IsDigit))
            {
                CtdenStock.Text = new string(e.NewTextValue.Where(char.IsDigit).ToArray());
            }
        }

        private void OnPrecioChanged(object sender, TextChangedEventArgs e)
        {
            if (!e.NewTextValue.All(char.IsDigit) && !e.NewTextValue.EndsWith("."))
            {
                Precio.Text = new string(e.NewTextValue.Where(c => char.IsDigit(c) || c == '.').ToArray());
            }
        }

        private bool IsNumeric(string value)
        {
            return double.TryParse(value, out _);
        }
    }
}
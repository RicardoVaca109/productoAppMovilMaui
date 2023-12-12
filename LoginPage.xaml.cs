using CommunityToolkit.Maui.Core;
using productoApp.Models;
using productoApp.Services;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace productoApp
{
    public partial class LoginPage : ContentPage
    {
        private User _usuarios;
        private readonly APIService _APIService;
       

        public LoginPage(APIService apiservice)
        {
            InitializeComponent();
            _APIService = apiservice;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            /*string username = Preferences.Get("username", "0");
            if (!username.Equals("0"))
            {
                Navigation.PushAsync(new ProductoPage(_APIService));
            }*/
        }

        private async void OnClickLogin(object sender, EventArgs e)
        {
            _usuarios = new User
            {
                UserMail = Username.Text,
                UserPassword = Password.Text
            };
            bool isValidUser = await _APIService.VerificarUsuario(_usuarios);
            if (isValidUser)
            {
                // Usuario válido, puedes realizar la navegación a la siguiente página
                await Navigation.PushAsync(new ProductoPage(_APIService));
            }
            else
            {
                // Muestra una alerta u otro mensaje indicando que el inicio de sesión falló
                await DisplayAlert("Error", "Inicio de sesión fallido/Credenciales incorrectas", "OK");
            }

            
        }

    }
}
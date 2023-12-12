using productoApp.Services;
using productoApp;

namespace productoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            APIService apiservice = new APIService();
            //MainPage = new NavigationPage(new ProductoPage(apiservice));
            MainPage = new NavigationPage(new LoginPage(apiservice));
        }
    }
}
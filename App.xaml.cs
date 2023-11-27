using productoApp.Services;

namespace productoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            APIService apiservice = new APIService();
            MainPage = new NavigationPage(new ProductoPage(apiservice));
        }
    }
}
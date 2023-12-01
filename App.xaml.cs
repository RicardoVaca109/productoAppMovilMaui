using productoApp.Services;

namespace productoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //APIService apiservice = new APIService(); apiservice
            MainPage = new NavigationPage(new ProductoPage());
        }
    }
}
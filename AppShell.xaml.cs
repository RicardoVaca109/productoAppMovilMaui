namespace productoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NuevoProducto), typeof(NuevoProducto));
            Routing.RegisterRoute(nameof(ProductoPage), typeof(ProductoPage));
        }
    }
}
using Xamarin.Forms;

namespace MenuItemDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.MenuItemXamlMvvmPage());
        }
    }
}

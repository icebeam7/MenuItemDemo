using Xamarin.Forms;

namespace MenuItemDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.MenuItemXamlMvvmPage();
        }
    }
}

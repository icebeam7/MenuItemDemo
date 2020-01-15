using MenuItemDemo.Services;
using MenuItemDemo.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuItemDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItemXamlMvvmPage : ContentPage
    {
        public MenuItemXamlMvvmPage()
        {
            InitializeComponent();

            BindingContext = new ListPageViewModel(DataService.GetListItems());
        }
    }
}
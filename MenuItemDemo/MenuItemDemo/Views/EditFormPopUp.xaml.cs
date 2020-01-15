using MenuItemDemo.ViewModels;

using Xamarin.Forms.Xaml;

using Rg.Plugins.Popup.Pages;

namespace MenuItemDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditFormPopUp : PopupPage
    {
        public EditFormPopUp(ListPageViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }
    }
}
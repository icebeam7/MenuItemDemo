using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using MenuItemDemo.Views;

using Xamarin.Forms;

using Rg.Plugins.Popup.Services;

namespace MenuItemDemo.ViewModels
{
    public class ListPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<string> items;

        public ObservableCollection<string> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                NotifyPropertyChanged();
            }
        }

        string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message != value)
                {
                    message = value;
                    NotifyPropertyChanged();
                }
            }
        }

        string selectedItem;
        public string SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string previousItem;

        public ListPageViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        public ListPageViewModel(List<string> startingItems)
        {
            Items = new ObservableCollection<string>(startingItems);
        }

        public ICommand EditCommand => new Command<string>(async (string item) =>
        {
            Message = $"Edit command was called on: {item}";
            previousItem = item;

            SelectedItem = item;
            await PopupNavigation.Instance.PushAsync(new EditFormPopUp(this));
        });

        public ICommand DeleteCommand => new Command<string>((string item) =>
        {
            Message = $"Delete command was called on: {item}";
            items.Remove(item);
        });

        public ICommand SaveCommand => new Command(async () =>
        {
            Items[Items.IndexOf(previousItem)] = SelectedItem;
            await PopupNavigation.Instance.PopAsync();
        });

        public ICommand CloseCommand => new Command(async () =>
        {
            await PopupNavigation.Instance.PopAsync();
        });

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
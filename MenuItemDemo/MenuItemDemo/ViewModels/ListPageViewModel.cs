using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using MenuItemDemo.Views;
using MenuItemDemo.Models;

using Xamarin.Forms;

using Rg.Plugins.Popup.Services;

namespace MenuItemDemo.ViewModels
{
    public class ListPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<Project> items;

        public ObservableCollection<Project> Items
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

        Project selectedItem;

        public Project SelectedItem
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

        private Project previousItem;

        public ListPageViewModel()
        {
            Items = new ObservableCollection<Project>();
        }

        public ListPageViewModel(List<Project> startingItems)
        {
            Items = new ObservableCollection<Project>(startingItems);
        }

        public ICommand EditCommand => new Command<Project>(async (Project item) =>
        {
            Message = $"Edit command was called on: {item.ProjectId} - {item.ProjectName}";
            previousItem = item;

            SelectedItem = item;
            await PopupNavigation.Instance.PushAsync(new EditFormPopUp(this));
        });

        public ICommand DeleteCommand => new Command<Project>((Project item) =>
        {
            Message = $"Delete command was called on: {item.ProjectId} - {item.ProjectName}";
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
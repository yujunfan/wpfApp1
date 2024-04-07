using System;
using System.Collections.ObjectModel;
using MahApps.Metro.IconPacks;
using MahAppsMetroHamburgerMenuNavigation.Mvvm;
using WpfApp1.window.Views.UI;

namespace WpfApp1.window.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        public ObservableCollection<MenuItem> Menu { get; } = new ObservableCollection<MenuItem>();

        public ObservableCollection<MenuItem> OptionsMenu { get; } = new ObservableCollection<MenuItem>();

        public ShellViewModel()
        {
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserSolid },
                Label = "mahAppsUI",
                NavigationType = typeof(BaseUI),
                NavigationDestination = new Uri("window/Views/UI/BaseUI.xaml", UriKind.RelativeOrAbsolute)
            });



        }
    }
}
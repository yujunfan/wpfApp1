using System;
using System.Collections.ObjectModel;
using MahApps.Metro.IconPacks;
using MahAppsMetroHamburgerMenuNavigation.Mvvm;
using WpfApp1.window.Views;

namespace WpfApp1.window.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        public ObservableCollection<MenuItem> Menu { get; } = new ObservableCollection<MenuItem>();

        public ObservableCollection<MenuItem> OptionsMenu { get; } = new ObservableCollection<MenuItem>();

        public ShellViewModel()
        {
            // Build the menus
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.BugSolid },
                Label = "数据绑定",
                NavigationType = typeof(DataBind),
                NavigationDestination = new Uri("window/Views/DataBind.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserSolid },
                Label = "mahAppsUI",
                NavigationType = typeof(UserPage),
                NavigationDestination = new Uri("window/Views/UI/BaseUI.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CoffeeSolid },
                Label = "文件操作",
                NavigationType = typeof(BreakPage),
                NavigationDestination = new Uri("window/Views/BreakPage.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.FontAwesomeBrands },
                Label = "Awesome",
                NavigationType = typeof(AwesomePage),
                NavigationDestination = new Uri("window/Views/AwesomePage.xaml", UriKind.RelativeOrAbsolute)
            });

            this.OptionsMenu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.CogsSolid },
                Label = "Settings",
                NavigationType = typeof(SettingsPage),
                NavigationDestination = new Uri("window/Views/SettingsPage.xaml", UriKind.RelativeOrAbsolute)
            });
            this.OptionsMenu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.InfoCircleSolid },
                Label = "About",
                NavigationType = typeof(AboutPage),
                NavigationDestination = new Uri("window/Views/AboutPage.xaml", UriKind.RelativeOrAbsolute)
            });
        }
    }
}
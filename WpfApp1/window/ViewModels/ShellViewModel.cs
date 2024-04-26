using System;
using System.Collections.ObjectModel;
using MahApps.Metro.IconPacks;
using MahAppsMetroHamburgerMenuNavigation.Mvvm;
using WpfApp1.window.Views.UI;
using WpfApp1.window.Views.Device;
using WpfApp1.window.Views.File;
using WpfApp1.window.Views.TaskOrder;

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
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.BluetoothBrands },
                Label = "设备管理",
                NavigationType = typeof(Device),
                NavigationDestination = new Uri("window/Views/Device/Device.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.FileSolid },
                Label = "文件管理",
                NavigationType = typeof(File),
                NavigationDestination = new Uri("window/Views/File/File.xaml", UriKind.RelativeOrAbsolute)
            });
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.TasksSolid },
                Label = "任务管理",
                NavigationType = typeof(TaskOrder),
                NavigationDestination = new Uri("window/Views/TaskOrder/TaskOrder.xaml", UriKind.RelativeOrAbsolute)
            });



        }
    }
}
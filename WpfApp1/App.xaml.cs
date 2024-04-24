using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ControlzEx.Theming;
using MahApps.Metro.Theming;

namespace WpfApp1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Add custom theme resource dictionaries
            //You should replace SampleApp with your application name
            //and the correct place where your custom theme lives
            var theme = ThemeManager.Current.AddLibraryTheme(
                new LibraryTheme(
                    new Uri("Style/MahThemes.xaml", UriKind.RelativeOrAbsolute),
                    MahAppsLibraryThemeProvider.DefaultInstance
                    )
                );

            ThemeManager.Current.ChangeTheme(this, theme);
        }
        public App()
        {
            InitializeComponent();
        }
    }
}

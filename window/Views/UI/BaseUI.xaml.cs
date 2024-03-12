using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
public class Artist
{
    public string Name { get; set; }
}


public static class SampleData
{
    public static ObservableCollection<Artist> Artists { get; } = new ObservableCollection<Artist>()
    {
        new Artist { Name = "Picasso" },
        new Artist { Name = "Van Gogh" },
        new Artist { Name = "Monet" }
    };
}

namespace WpfApp1.window.Views.UI
{
    /// <summary>
    /// BaseUI.xaml 的交互逻辑
    /// </summary>
    public partial class BaseUI : Page
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        public BaseUI()
        {
            InitializeComponent();
        }


        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);
    }
}

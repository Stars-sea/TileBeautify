using System;
using System.Collections.Generic;
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

namespace TileBeautifyWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReplaceIcon_Selected(object sender, RoutedEventArgs e) => Content = new ReplaceIconPage();

        private void PictureTile_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void AboutAuthor_Selected(object sender, RoutedEventArgs e) => Content = new AboutAuthorPage();
    }

    public class OptionButtonContent
    {
        public ImageSource ImageSource { get; set; }
        public string      Content     { get; set; }
        public string      Describe    { get; set; }
    }
}

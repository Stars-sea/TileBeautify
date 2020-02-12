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
    /// AboutMePage.xaml 的交互逻辑
    /// </summary>
    public partial class AboutAuthorPage : Page
    {
        public AboutAuthorPage()
        {
            InitializeComponent();
        }

        private void ClearBar()
        {
            if (RightBar is null) return;
            foreach (UIElement element in RightBar.Children)
                element.Visibility = Visibility.Collapsed;
        }

        private void Instruction_Selected(object sender, RoutedEventArgs e)
        {
            ClearBar();
            Instruction.Visibility = Visibility.Visible;
        }

        private void About_Selected(object sender, RoutedEventArgs e)
        {
            ClearBar();
            About.Visibility = Visibility.Visible;
        }

        private void Sponsor_Selected(object sender, RoutedEventArgs e)
        {
            ClearBar();
            Sponsor.Visibility = Visibility.Visible;
        }
    }
}

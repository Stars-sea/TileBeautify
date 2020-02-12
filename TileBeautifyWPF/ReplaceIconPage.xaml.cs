using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using IWshRuntimeLibrary;
using System.Globalization;

namespace TileBeautifyWPF
{
    /// <summary>
    /// ReplaceIconPage.xaml 的交互逻辑
    /// </summary>
    public partial class ReplaceIconPage : Page
    {
        public ReplaceIconPage()
        {
            InitializeComponent();
        }

        // 切换页面
        private void ClearBar()
        {
            foreach (UIElement panel in RightBar.Children)
                panel.Visibility = Visibility.Collapsed;
        }

        private void FilePathItem_Selected(object sender, RoutedEventArgs e)
        {
            ClearBar();
            FilePath.Visibility = Visibility.Visible;
        }

        private void BgColorItem_Selected(object sender, RoutedEventArgs e)
        {
            ClearBar();
            BgColor.Visibility = Visibility.Visible;
        }

        private void FgColorItem_Selected(object sender, RoutedEventArgs e)
        {
            ClearBar();
        }

        private void TileNameItem_Selected(object sender, RoutedEventArgs e)
        {
            ClearBar();
        }

        private void LogoPathItem_Selected(object sender, RoutedEventArgs e)
        {
            ClearBar();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: 实现
        }

        // 设置文件路径
        private string GetPath(string url)
        {
            if (url.StartsWith("\""))
                return url.Substring(1, url.IndexOf('"'));
            return url.Substring(0, url.IndexOf(' '));
        }

        private void SetUrl(string url)
        {
            string path = GetPath(url);
            if (path.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) ||
                path.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase)) {
                UrlText.Text = url;
            }
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog {
                Title = "应用程序路径/链接",
                Filter = "应用程序/快捷方式|*.exe;*.lnk"
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                SetUrl(dialog.FileName);
        }

        private void FilePath_Drop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filePath in filePaths)
                SetUrl(filePath);
        }

        private void UrlText_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
            FilePath_Drop(sender, e);
        }

        private void UrlText_LostFocus(object sender, RoutedEventArgs e)
        {
            string url = UrlText.Text;
            if (!string.IsNullOrEmpty(url))
            {
                if (System.IO.File.Exists(url))
                    return;

                if (!url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) &&
                    !url.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                    url = "http://" + url;
                if (!Regex.IsMatch(url, @"https{0,1}://.*\..*")) {
                    ErrorText.Visibility = Visibility.Visible;
                }
            }
        }

        private void UrlText_GotFocus(object sender, RoutedEventArgs e) => ErrorText.Visibility = Visibility.Collapsed;

        private void CustomColorButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog {
                FullOpen = false,
                AnyColor = true
            };
            colorDialog.ShowDialog();
            CustomColorPanel.Visibility = Visibility.Visible;
            PreviewRect.Fill = new SolidColorBrush(new Color() {
                R = colorDialog.Color.R,
                G = colorDialog.Color.G,
                B = colorDialog.Color.B
            });
        }

        // 设置颜色
    }
}

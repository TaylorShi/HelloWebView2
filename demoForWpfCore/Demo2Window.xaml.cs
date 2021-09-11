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

namespace demoForWpfCore
{
    /// <summary>
    /// Interaction logic for Demo2Window.xaml
    /// </summary>
    public partial class Demo2Window : Window
    {
        public Demo2Window()
        {
            InitializeComponent();
            Loaded += Demo2Window_Loaded;
        }

        private void Demo2Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxForSource.Text = WebViewForMain.Source?.ToString();
        }

        private void BorderForNavi_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var sourceContext = TextBoxForSource.Text?.Trim();
            WebViewForMain.CoreWebView2.Navigate(sourceContext);
        }

        private void TextBoxForSource_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                BorderForNavi_MouseDown(null, null);
            }
        }
    }
}

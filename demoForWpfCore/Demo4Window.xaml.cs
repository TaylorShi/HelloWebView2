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
    /// Interaction logic for Demo4Window.xaml
    /// </summary>
    public partial class Demo4Window : Window
    {
        private bool _isNavigationProgress;
        public bool IsNavigationProgress 
        { 
            get 
            {
                return _isNavigationProgress;
            }
            set 
            {
                _isNavigationProgress = value;
                GirdForProgress.IsEnabled = value;
                GirdForProgress.IsIndeterminate = value;
                GirdForProgress.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            } 
        }

        public Demo4Window()
        {
            InitializeComponent();
            Loaded += Demo4Window_Loaded;
            WebViewForMain.NavigationStarting += WebViewForMain_NavigationStarting;
            WebViewForMain.NavigationCompleted += WebViewForMain_NavigationCompleted;
        }

        private void WebViewForMain_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                TextBoxForSource.Text = WebViewForMain.Source?.ToString();
            }

            IsNavigationProgress = false;
        }

        private void WebViewForMain_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            var uri = e.Uri;
            if (!uri.ToLower().StartsWith("https://"))
            {
                WebViewForMain.CoreWebView2.ExecuteScriptAsync($"alert('{uri} 不安全，请使用HTTPS地址重新访问！')");
                e.Cancel = true;
            }

            IsNavigationProgress = true;
        }

        private void Demo4Window_Loaded(object sender, RoutedEventArgs e)
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

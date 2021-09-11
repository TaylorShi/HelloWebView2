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
    /// Interaction logic for Demo3Window.xaml
    /// </summary>
    public partial class Demo3Window : Window
    {
        public Demo3Window()
        {
            InitializeComponent();
            InitializeAsync();
            WebViewForMain.NavigationStarting += WebViewForMain_NavigationStarting;
            WebViewForMain.NavigationCompleted += WebViewForMain_NavigationCompleted;
        }

        async void InitializeAsync()
        {
            // 确保WebView对象已经初始化完成
            await WebViewForMain.EnsureCoreWebView2Async(null);

            // 监听来自WebView的消息
            WebViewForMain.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

            // 模拟WebView的网站发送消息
            await WebViewForMain.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");

            // 模拟WebView的网站监听消息
            await WebViewForMain.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");
        }

        private void CoreWebView2_WebMessageReceived(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            // 试图以String的方式接收消息内容
            var messageContent = e.TryGetWebMessageAsString();

            // 以系统弹窗的方式展示消息内容
            MessageBox.Show(messageContent);
        }

        private void WebViewForMain_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                TextBoxForSource.Text = WebViewForMain.Source?.ToString();
            }
        }

        private void WebViewForMain_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            var uri = e.Uri;
            if (!uri.ToLower().StartsWith("https://"))
            {
                WebViewForMain.CoreWebView2.ExecuteScriptAsync($"alert('{uri} 不安全，请使用HTTPS地址重新访问！')");
                e.Cancel = true;
            }
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

        private void BorderForPost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var messageContext = TextBoxForMessage.Text?.Trim();
            WebViewForMain.CoreWebView2.PostWebMessageAsString(messageContext);
        }

        private void TextBoxForMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BorderForPost_MouseDown(null, null);
            }
        }
    }
}
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace demoForWinUi3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
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

                //BorderForNaviRefresh.IsEnabled = !value;
                //TextBlockForNaviRefresh.Foreground = !value ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Gray);

                BorderForNaviStop.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
                BorderForNaviRefresh.Visibility = !value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Title = "MiniEdge";
            WebViewForMain.NavigationStarting += WebViewForMain_NavigationStarting;
            WebViewForMain.NavigationCompleted += WebViewForMain_NavigationCompleted;
            //WebViewForMain.KeyDown += WebViewForMain_KeyDown;
            WebViewForMain.CoreWebView2Initialized += WebViewForMain_CoreWebView2Initialized;
        }

        private void WebViewForMain_CoreWebView2Initialized(object? sender, CoreWebView2InitializedEventArgs e)
        {
            if (e.Exception!=null)
            {
                WebViewForMain.CoreWebView2.ProcessFailed += CoreWebView2_ProcessFailed;
            }
            else
            {
                //MessageBox.Show($"WebView2创建失败，发生异常 = {e.InitializationException}");
            }
        }


        private void CoreWebView2_ProcessFailed(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2ProcessFailedEventArgs e)
        {
            switch (e.ProcessFailedKind)
            {
                // 浏览器进程退出
                case CoreWebView2ProcessFailedKind.BrowserProcessExited:
                    {

                    }
                    break;
                // 浏览器渲染进程未响应
                case CoreWebView2ProcessFailedKind.RenderProcessUnresponsive:
                    {

                    }
                    break;
                // 浏览器渲染进程退出
                case CoreWebView2ProcessFailedKind.RenderProcessExited:
                    {

                    }
                    break;
                // 框架渲染进程退出
                //case CoreWebView2ProcessFailedKind.FrameRenderProcessExited:
                    {

                    }
                    break;
                default:
                    {
                        // Show the process failure details. Apps can collect info for their logging purposes.
                        StringBuilder messageBuilder = new StringBuilder();
                        messageBuilder.AppendLine($"Process kind: {e.ProcessFailedKind}");
                        // messageBuilder.AppendLine($"Reason: {e.Reason}");
                        //messageBuilder.AppendLine($"Exit code: {e.ExitCode}");
                        //messageBuilder.AppendLine($"Process description: {e.ProcessDescription}");
                        System.Threading.SynchronizationContext.Current.Post((_) =>
                        {
                           // MessageBox.Show(messageBuilder.ToString(), "Child process failed", MessageBoxButton.OK);
                        }, null);
                    }
                    break;
            }
        }

        //private void WebViewForMain_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.IsRepeat) return;
        //    bool ctrl = e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl);
        //    bool alt = e.KeyboardDevice.IsKeyDown(Key.LeftAlt) || e.KeyboardDevice.IsKeyDown(Key.RightAlt);
        //    bool shift = e.KeyboardDevice.IsKeyDown(Key.LeftShift) || e.KeyboardDevice.IsKeyDown(Key.RightShift);

        //    if (e.Key == Key.N && ctrl && !alt && !shift)
        //    {
        //        new MainWindow().Show();
        //        e.Handled = true;
        //    }
        //    else if (e.Key == Key.W && ctrl && !alt && !shift)
        //    {
        //        Close();
        //        e.Handled = true;
        //    }
        //}

        private void WebViewForMain_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                TextBoxForNaviAddress.Text = WebViewForMain.Source?.ToString();
            }

            IsNavigationProgress = false;
            UpdateNaviButtonStatus();
        }

        private void WebViewForMain_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            //var uri = e.Uri;
            //if (!uri.ToLower().StartsWith("https://"))
            //{
            //    WebViewForMain.CoreWebView2.ExecuteScriptAsync($"alert('{uri} 不安全，请使用HTTPS地址重新访问！')");
            //    e.Cancel = true;
            //}

            IsNavigationProgress = true;
        }

        //private void Demo4Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    TextBoxForNaviAddress.Text = WebViewForMain.Source?.ToString();
        //}

        #region NaviButton

        /// <summary>
        /// 导航栏-后退按钮-点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderForNaviBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            #region BorderForNaviBack_MouseDown

            if (WebViewForMain.CanGoBack)
            {
                WebViewForMain.GoBack();
            }
            else
            {
                UpdateNaviButtonStatus();
            }

            #endregion
        }

        /// <summary>
        /// 导航栏-前进按钮-点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderForNaviForward_Tapped(object sender, TappedRoutedEventArgs e)
        {
            #region BorderForNaviForward_MouseDown

            if (WebViewForMain.CanGoForward)
            {
                WebViewForMain.GoForward();
            }
            else
            {
                UpdateNaviButtonStatus();
            }

            #endregion
        }

        /// <summary>
        /// 导航栏-主页按钮-点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderForNaviHome_Tapped(object sender, TappedRoutedEventArgs e)
        {
            #region BorderForNaviHome_MouseDown

            WebViewForMain.CoreWebView2.Navigate("https://www.bing.com");
            UpdateNaviButtonStatus();

            #endregion
        }

        /// <summary>
        /// 导航栏-指定按钮-点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderForNaviTarget_Tapped(object sender, TappedRoutedEventArgs e)
        {
            #region BorderForNaviTarget_MouseDown

            var sourceContent = TextBoxForNaviAddress.Text?.Trim() ?? string.Empty;
            if (!string.IsNullOrEmpty(sourceContent))
            {
                Uri? sourceUri;

                // 如果当前地址是格式化合规的地址，那么直接使用
                if (Uri.IsWellFormedUriString(sourceContent, UriKind.Absolute))
                {
                    sourceUri = new Uri(sourceContent);
                }
                // 如果当前地址含.符号切不含空格，那么自动追加前缀
                else if (!sourceContent.Contains(" ") && sourceContent.Contains("."))
                {
                    sourceUri = new Uri("http://" + sourceContent);
                }
                // 如果当前地址不属于上诉情况，那么通过内置搜索引擎搜索
                else
                {
                    var searchKeywords = string.Join("+", Uri.EscapeDataString(sourceContent).Split(new string[] { "%20" }, StringSplitOptions.RemoveEmptyEntries));
                    var bingSearchAddress = $"https://bing.com/search?q={searchKeywords}";
                    sourceUri = new Uri(bingSearchAddress);
                }

                if (sourceUri != null)
                {
                    WebViewForMain.CoreWebView2.Navigate(sourceUri.ToString());
                }
            }

            #endregion
        }

        /// <summary>
        /// 导航栏-刷新按钮-点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderForNaviRefresh_Tapped(object sender, TappedRoutedEventArgs e)
        {
            #region BorderForNaviRefresh_MouseDown

            WebViewForMain.Reload();
            UpdateNaviButtonStatus();

            #endregion
        }

        /// <summary>
        /// 导航栏-停止按钮-点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderForNaviStop_Tapped(object sender, TappedRoutedEventArgs e)
        {
            #region BorderForNaviStop_MouseDown

            WebViewForMain.Close();
            UpdateNaviButtonStatus();

            #endregion
        }

        /// <summary>
        /// 导航栏-地址输入框-快捷键(回车)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxForNaviAddress_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            #region TextBoxForNaviAddress_KeyDown

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                BorderForNaviTarget_Tapped(null, null);
            }

            #endregion
        }

        #endregion

        #region ButtonEffect

        /// <summary>
        /// 更新导航栏-按钮-状态
        /// </summary>
        private void UpdateNaviButtonStatus()
        {
            #region UpdateNaviButtonStatus

            var isCanGoBack = WebViewForMain.CanGoBack;
            //BorderForNaviBack.IsEnabled = isCanGoBack;
            TextBlockForNaviBack.Foreground = isCanGoBack ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Gray);

            var isCanGoForward = WebViewForMain.CanGoForward;
            //BorderForNaviForward.IsEnabled = isCanGoForward;
            TextBlockForNaviForward.Foreground = isCanGoForward ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Gray);

            #endregion
        }

        private void BorderForButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var border = sender as Border;
            border.Background = new SolidColorBrush(Colors.White);
            border.Focus(FocusState.Pointer);
        }

        private void BorderForButton_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var border = sender as Border;
            border.Background = new SolidColorBrush(Colors.Transparent);
            border.Focus(FocusState.Pointer);
        }

        //private void TextBoxForNaviAddress_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    BorderForNaviAddress.BorderBrush = new SolidColorBrush(Color.FromRgb(143, 177, 229));
        //    BorderForNaviAddress.BorderThickness = new Thickness(1.5);
        //}

        //private void TextBoxForNaviAddress_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    BorderForNaviAddress.BorderBrush = new SolidColorBrush(Colors.Gray);
        //    BorderForNaviAddress.BorderThickness = new Thickness(1);
        //}

        #endregion
    }
}

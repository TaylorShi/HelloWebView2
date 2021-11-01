﻿using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace demoForWpfCoreModernUI
{
    /// <summary>
    /// Interaction logic for Demo6Window.xaml
    /// </summary>
    public partial class Demo6Window : Window
    {
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, DwmWindowAttribute dwAttribute, ref int pvAttribute, int cbAttribute);

        [Flags]
        public enum DwmWindowAttribute : uint
        {
            DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
            DWMWA_MICA_EFFECT = 1029
        }

        // Enable Mica on the given HWND.
        public static void EnableMica(HwndSource source, bool darkThemeEnabled)
        {
            int trueValue = 0x01;
            int falseValue = 0x00;

            // Set dark mode before applying the material, otherwise you'll get an ugly flash when displaying the window.
            if (darkThemeEnabled)
                DwmSetWindowAttribute(source.Handle, DwmWindowAttribute.DWMWA_USE_IMMERSIVE_DARK_MODE, ref trueValue, Marshal.SizeOf(typeof(int)));
            else
                DwmSetWindowAttribute(source.Handle, DwmWindowAttribute.DWMWA_USE_IMMERSIVE_DARK_MODE, ref falseValue, Marshal.SizeOf(typeof(int)));

            DwmSetWindowAttribute(source.Handle, DwmWindowAttribute.DWMWA_MICA_EFFECT, ref trueValue, Marshal.SizeOf(typeof(int)));
        }

        public static void UpdateStyleAttributes(HwndSource hwnd)
        {
            // You can avoid using ModernWpf here and just rely on Win32 APIs or registry parsing if you want to.
            var darkThemeEnabled = ModernWpf.ThemeManager.Current.ActualApplicationTheme == ModernWpf.ApplicationTheme.Dark;

            EnableMica(hwnd, darkThemeEnabled);
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            // Apply Mica brush and ImmersiveDarkMode if needed
            UpdateStyleAttributes((HwndSource)sender);

            // Hook to Windows theme change to reapply the brushes when needed
            ModernWpf.ThemeManager.Current.ActualApplicationThemeChanged += (s, ev) => UpdateStyleAttributes((HwndSource)sender);
        }

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

                BorderForNaviRefresh.IsEnabled = !value;
                TextBlockForNaviRefresh.Foreground = !value ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Gray);

                BorderForNaviStop.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
                BorderForNaviRefresh.Visibility = !value ? Visibility.Visible : Visibility.Collapsed;
            } 
        }

        public Demo6Window()
        {
            InitializeComponent();
            Loaded += Demo6Window_Loaded;
            WebViewForMain.NavigationStarting += WebViewForMain_NavigationStarting;
            WebViewForMain.NavigationCompleted += WebViewForMain_NavigationCompleted;
            WebViewForMain.KeyDown += WebViewForMain_KeyDown;
            WebViewForMain.CoreWebView2InitializationCompleted += WebViewForMain_CoreWebView2InitializationCompleted;
        }

        private async void Demo6Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get PresentationSource
            PresentationSource presentationSource = PresentationSource.FromVisual((Visual)sender);

            // Subscribe to PresentationSource's ContentRendered event
            presentationSource.ContentRendered += Window_ContentRendered;

            TextBoxForNaviAddress.Text = WebViewForMain.Source?.ToString();

            await WebViewForMain.EnsureCoreWebView2Async();
            //set WebView2 control settings
            WebViewForMain.CoreWebView2.Settings.AreHostObjectsAllowed = true;
            WebViewForMain.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = true;
            WebViewForMain.CoreWebView2.Settings.IsScriptEnabled = true;
            WebViewForMain.CoreWebView2.Settings.IsWebMessageEnabled = true;

            WebViewForMain.CoreWebView2.AddHostObjectToScript("webView2Bridge", new HostObject.C2WHostObject());
        }

        #region WebViewEvent

        /// <summary>
        /// 浏览器实例-导航开始事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebViewForMain_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            #region WebViewForMain_NavigationStarting

            //var uri = e.Uri;
            //if (!uri.ToLower().StartsWith("https://"))
            //{
            //    WebViewForMain.CoreWebView2.ExecuteScriptAsync($"alert('{uri} 不安全，请使用HTTPS地址重新访问！')");
            //    e.Cancel = true;
            //}

            IsNavigationProgress = true;

            #endregion
        }

        /// <summary>
        /// 浏览器实例-导航完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebViewForMain_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            #region WebViewForMain_NavigationCompleted

            if (e.IsSuccess)
            {
                TextBoxForNaviAddress.Text = WebViewForMain.Source?.ToString();
            }

            IsNavigationProgress = false;
            UpdateNaviButtonStatus();

            #endregion
        }

        /// <summary>
        /// 浏览器实例-键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebViewForMain_KeyDown(object sender, KeyEventArgs e)
        {
            #region WebViewForMain_KeyDown

            if (e.IsRepeat) return;
            bool ctrl = e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl);
            bool alt = e.KeyboardDevice.IsKeyDown(Key.LeftAlt) || e.KeyboardDevice.IsKeyDown(Key.RightAlt);
            bool shift = e.KeyboardDevice.IsKeyDown(Key.LeftShift) || e.KeyboardDevice.IsKeyDown(Key.RightShift);

            if (e.Key == Key.N && ctrl && !alt && !shift)
            {
                new MainWindow().Show();
                e.Handled = true;
            }
            else if (e.Key == Key.W && ctrl && !alt && !shift)
            {
                Close();
                e.Handled = true;
            }

            #endregion
        }

        /// <summary>
        /// 浏览器实例-内核初始化完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebViewForMain_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            #region WebViewForMain_CoreWebView2InitializationCompleted

            if (e.IsSuccess)
            {
                WebViewForMain.CoreWebView2.ProcessFailed += WebViewForMain_CoreWebView2_ProcessFailed;
            }
            else
            {
                MessageBox.Show($"WebView2创建失败，发生异常 = {e.InitializationException}");
            }

            #endregion
        }

        /// <summary>
        /// 浏览器实例-内核-进程异常事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebViewForMain_CoreWebView2_ProcessFailed(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2ProcessFailedEventArgs e)
        {
            #region WebViewForMain_CoreWebView2_ProcessFailed

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
                case CoreWebView2ProcessFailedKind.FrameRenderProcessExited:
                    {

                    }
                    break;
                default:
                    {
                        // Show the process failure details. Apps can collect info for their logging purposes.
                        StringBuilder messageBuilder = new StringBuilder();
                        messageBuilder.AppendLine($"Process kind: {e.ProcessFailedKind}");
                        messageBuilder.AppendLine($"Reason: {e.Reason}");
                        messageBuilder.AppendLine($"Exit code: {e.ExitCode}");
                        messageBuilder.AppendLine($"Process description: {e.ProcessDescription}");
                        System.Threading.SynchronizationContext.Current.Post((_) =>
                        {
                            MessageBox.Show(messageBuilder.ToString(), "Child process failed", MessageBoxButton.OK);
                        }, null);
                    }
                    break;
            }

            #endregion
        } 

        #endregion

        #region NaviButton

        /// <summary>
        /// 导航栏-后退按钮-点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderForNaviBack_MouseDown(object sender, MouseButtonEventArgs e)
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
        private void BorderForNaviForward_MouseDown(object sender, MouseButtonEventArgs e)
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
        private void BorderForNaviHome_MouseDown(object sender, MouseButtonEventArgs e)
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
        /// <param name="e"></param>f
        private void BorderForNaviTarget_MouseDown(object sender, MouseButtonEventArgs e)
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
        private void BorderForNaviRefresh_MouseDown(object sender, MouseButtonEventArgs e)
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
        private void BorderForNaviStop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            #region BorderForNaviStop_MouseDown

            WebViewForMain.Stop();
            UpdateNaviButtonStatus();

            #endregion
        }

        /// <summary>
        /// 导航栏-地址输入框-快捷键(回车)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxForNaviAddress_KeyDown(object sender, KeyEventArgs e)
        {
            #region TextBoxForNaviAddress_KeyDown

            if (e.Key == Key.Enter)
            {
                BorderForNaviTarget_MouseDown(null, null);
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
            BorderForNaviBack.IsEnabled = isCanGoBack;
            TextBlockForNaviBack.Foreground = isCanGoBack ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Gray);

            var isCanGoForward = WebViewForMain.CanGoForward;
            BorderForNaviForward.IsEnabled = isCanGoForward;
            TextBlockForNaviForward.Foreground = isCanGoForward ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.Gray); 

            #endregion
        }

        private void BorderForButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var border = sender as Border;
            if (border.IsEnabled)
            {
                border.Background = new SolidColorBrush(Colors.White);
                border.Focus();
            }
        }

        private void BorderForButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var border = sender as Border;
            if (border.IsEnabled)
            {
                border.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void TextBoxForNaviAddress_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderForNaviAddress.BorderBrush = new SolidColorBrush(Color.FromRgb(143, 177, 229));
            BorderForNaviAddress.BorderThickness = new Thickness(1.5);
        }

        private void TextBoxForNaviAddress_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderForNaviAddress.BorderBrush = new SolidColorBrush(Colors.Gray);
            BorderForNaviAddress.BorderThickness = new Thickness(1);
        }

        #endregion
    }
}

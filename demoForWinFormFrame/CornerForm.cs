using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoForWinFormFrame
{
    public partial class CornerForm : Form
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
                GirdForProgress.Enabled = GirdForProgress.Visible = value;
                LabelButtonForNaviRefresh.Visible = !value;
                LabelButtonForNaviStop.Visible = value;
            }
        }

        public CornerForm()
        {
            InitializeComponent();
            Load += CornerForm_Load;
            WebViewForMain.NavigationStarting += WebViewForMain_NavigationStarting;
            WebViewForMain.NavigationCompleted += WebViewForMain_NavigationCompleted;
            WebViewForMain.KeyDown += WebViewForMain_KeyDown;
            WebViewForMain.CoreWebView2InitializationCompleted += WebViewForMain_CoreWebView2InitializationCompleted;
        }

        private void CornerForm_Load(object sender, EventArgs e)
        {
            InitButtonStyle();
        }

        #region WebViewEvent

        /// <summary>
        /// 浏览器实例-导航开始事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebViewForMain_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
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
        private void WebViewForMain_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            #region WebViewForMain_NavigationCompleted

            if (e.IsSuccess)
            {
                TextBoxForNaviAddress.SetText(WebViewForMain.Source?.ToString());
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

            //if (e) return;
            //bool ctrl = e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl);
            //bool alt = e.KeyboardDevice.IsKeyDown(Key.LeftAlt) || e.KeyboardDevice.IsKeyDown(Key.RightAlt);
            //bool shift = e.KeyboardDevice.IsKeyDown(Key.LeftShift) || e.KeyboardDevice.IsKeyDown(Key.RightShift);

            //if (e.Key == Key.N && ctrl && !alt && !shift)
            //{
            //    new MainWindow().Show();
            //    e.Handled = true;
            //}
            //else if (e.Key == Key.W && ctrl && !alt && !shift)
            //{
            //    Close();
            //    e.Handled = true;
            //}

            #endregion
        }

        /// <summary>
        /// 浏览器实例-内核初始化完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebViewForMain_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
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
        private void WebViewForMain_CoreWebView2_ProcessFailed(object sender, Microsoft.Web.WebView2.Core.CoreWebView2ProcessFailedEventArgs e)
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
                            MessageBox.Show(messageBuilder.ToString(), "Child process failed", MessageBoxButtons.OK);
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
        private void LabelButtonForNaviBack_Tapped()
        {
            #region LabelButtonForNaviBack_Tapped

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
        private void LabelButtonForNaviForward_Tapped()
        {
            #region LabelButtonForNaviForward_Tapped

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
        private void LabelButtonForNaviHome_Tapped()
        {
            #region LabelButtonForNaviHome_Tapped

            WebViewForMain.CoreWebView2.Navigate("https://www.bing.com");
            UpdateNaviButtonStatus();

            #endregion
        }

        /// <summary>
        /// 导航栏-指定按钮-点击事件
        /// </summary>
        private void LabelButtonForNaviTarget_Tapped()
        {
            #region LabelButtonForNaviTarget_Tapped

            var sourceContent = TextBoxForNaviAddress.Text?.Trim() ?? string.Empty;
            if (!string.IsNullOrEmpty(sourceContent))
            {
                Uri sourceUri;

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
        /// 导航栏-停止按钮-点击事件
        /// </summary>
        private void LabelButtonForNaviStop_Tapped()
        {
            #region LabelButtonForNaviStop_Tapped

            WebViewForMain.Stop();
            UpdateNaviButtonStatus();

            #endregion
        }

        /// <summary>
        /// 导航栏-刷新按钮-点击事件
        /// </summary>
        private void LabelButtonForNaviRefresh_Tapped()
        {
            #region LabelButtonForNaviRefresh_Tapped

            WebViewForMain.Reload();
            UpdateNaviButtonStatus(); 

            #endregion
        }

        /// <summary>
        /// 导航栏-地址输入框-快捷键(回车)
        /// </summary>
        /// <param name="e"></param>
        private void TextBoxForNaviAddress_KeyDowned(KeyEventArgs e)
        {
            #region TextBoxForNaviAddress_KeyDowned

            if (e.KeyCode == Keys.Enter)
            {
                LabelButtonForNaviTarget_Tapped();
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
            LabelButtonForNaviBack.Enabled = isCanGoBack;
            LabelButtonForNaviBack.SetColor(isCanGoBack ? Color.Black : Color.Gray);

            var isCanGoForward = WebViewForMain.CanGoForward;
            LabelButtonForNaviForward.Enabled = isCanGoForward;
            LabelButtonForNaviForward.SetColor(isCanGoForward ? Color.Black : Color.Gray);

            #endregion
        }

        private void InitButtonStyle()
        {
            // 后退按钮
            LabelButtonForNaviBack.SetText("\ue0a6");

            // 前进按钮
            LabelButtonForNaviForward.SetText("\ue0ab");

            // 停止按钮
            LabelButtonForNaviStop.SetText("\ue106", 22);

            // 刷新按钮
            LabelButtonForNaviRefresh.SetText("\ue149");

            // 主页按钮
            LabelButtonForNaviHome.SetText("\ue10f");

            // 搜索按钮
            LabelButtonForNaviTarget.SetText("\uf78b");
        }




        #endregion
    }
}

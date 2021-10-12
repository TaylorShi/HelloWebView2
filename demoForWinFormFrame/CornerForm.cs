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
        public CornerForm()
        {
            InitializeComponent();
            Load += CornerForm_Load;
        }

        private void CornerForm_Load(object sender, EventArgs e)
        {
            InitButtonStyle();
        }




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
            LabelButtonForNaviStop.SetText("\ue106", 26);

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

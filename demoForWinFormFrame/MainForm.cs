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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 后退按钮
            TextBlockForNaviBack.Text = "\ue0a6";
            TextBlockForNaviBack.Font = new Font(IconfontHelper.PFCC.Families[0], 24);

            // 前进按钮
            TextBlockForNaviForward.Text = "\ue0ab";
            TextBlockForNaviForward.Font = new Font(IconfontHelper.PFCC.Families[0], 24);

            // 停止按钮
            TextBlockForNaviStop.Text = "\ue106";
            TextBlockForNaviStop.Font = new Font(IconfontHelper.PFCC.Families[0], 26);

            // 刷新按钮
            TextBlockForNaviRefresh.Text = "\ue149";
            TextBlockForNaviRefresh.Font = new Font(IconfontHelper.PFCC.Families[0], 24);

            // 主页按钮
            TextBlockForNaviHome.Text = "\ue10f";
            TextBlockForNaviHome.Font = new Font(IconfontHelper.PFCC.Families[0], 24);

            // 搜索按钮
            TextBlockForNaviTarget.Text = "\uf78b";
            TextBlockForNaviTarget.Font = new Font(IconfontHelper.PFCC.Families[0], 24);
        }

        private void BorderForButton_MouseEnter(object sender, EventArgs e)
        {
            var border = sender as Panel;
            border.BackColor = Color.White;
            border.Focus();
        }

        private void BorderForButton_MouseLeave(object sender, EventArgs e)
        {
            var border = sender as Panel;
            border.BackColor = Color.Transparent;
            border.Focus();
        }

        private void TextBlockForNaviBack_MouseEnter(object sender, EventArgs e)
        {
            BorderForButton_MouseEnter(BorderForNaviBack, e);
        }

        private void TextBlockForNaviForward_MouseEnter(object sender, EventArgs e)
        {
            BorderForButton_MouseEnter(BorderForNaviForward, e);
        }

        private void TextBlockForNaviStop_MouseEnter(object sender, EventArgs e)
        {
            BorderForButton_MouseEnter(BorderForNaviStop, e);
        }

        private void TextBlockForNaviRefresh_MouseEnter(object sender, EventArgs e)
        {
            BorderForButton_MouseEnter(BorderForNaviRefresh, e);
        }

        private void TextBlockForNaviHome_MouseEnter(object sender, EventArgs e)
        {
            BorderForButton_MouseEnter(BorderForNaviHome, e);
        }

        private void TextBlockForNaviTarget_MouseEnter(object sender, EventArgs e)
        {
            BorderForButton_MouseEnter(BorderForNaviTarget, e);
        }
    }
}

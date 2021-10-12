using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoForWinFormFrame.Controls
{
    public partial class LabelButton : UserControl
    {
        public bool IsEnable { get; set; }

        public LabelButton()
        {
            InitializeComponent();
        }

        public void SetText(string iconFontValue, int fontSize = 24)
        {
            TextBlockForNaviBack.Text = iconFontValue;
            TextBlockForNaviBack.Font = new Font(IconfontHelper.PFCC.Families[0], fontSize);
        }

        public void SetColor(System.Drawing.Color iconFontColor)
        {
            TextBlockForNaviBack.ForeColor = iconFontColor;
        }

        public delegate void TappedEventHandler();
        public event TappedEventHandler Tapped;
        public void OnTapped()
        {
            if (Tapped != null)
                Tapped();
        }

        private void CornerRadiusPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsEnable)
            {
                OnTapped();
            }
        }

        private void TextBlockForNaviBack_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsEnable)
            {
                OnTapped();
            }
        }
    }
}

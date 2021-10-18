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
    public partial class CornerTextbox : UserControl
    {
        public CornerTextbox()
        {
            InitializeComponent();
        }

        public override string Text => TextBoxForInputBox.Text;

        public void SetText(string inputText)
        {
            TextBoxForInputBox.Text = inputText;
        }

        public delegate void KeyDownEventHandler(KeyEventArgs e);
        public event KeyDownEventHandler KeyDowned;
        public void OnKeyDowned(KeyEventArgs e)
        {
            if (KeyDowned != null)
                KeyDowned(e);
        }

        private void TextBoxForInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDowned(e);
        }
    }
}

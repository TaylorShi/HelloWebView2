
namespace demoForWinFormFrame.Controls
{
    partial class CornerTextbox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cornerRadiusPanel1 = new demoForWinFormFrame.Controls.CornerRadiusPanel();
            this.TextBoxForInputBox = new System.Windows.Forms.TextBox();
            this.cornerRadiusPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cornerRadiusPanel1
            // 
            this.cornerRadiusPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cornerRadiusPanel1.Controls.Add(this.TextBoxForInputBox);
            this.cornerRadiusPanel1.Location = new System.Drawing.Point(-9, -8);
            this.cornerRadiusPanel1.Name = "cornerRadiusPanel1";
            this.cornerRadiusPanel1.Size = new System.Drawing.Size(641, 116);
            this.cornerRadiusPanel1.TabIndex = 0;
            // 
            // TextBoxForInputBox
            // 
            this.TextBoxForInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxForInputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxForInputBox.Font = new System.Drawing.Font("宋体", 24F);
            this.TextBoxForInputBox.Location = new System.Drawing.Point(25, 21);
            this.TextBoxForInputBox.Multiline = true;
            this.TextBoxForInputBox.Name = "TextBoxForInputBox";
            this.TextBoxForInputBox.Size = new System.Drawing.Size(575, 44);
            this.TextBoxForInputBox.TabIndex = 0;
            this.TextBoxForInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxForInputBox_KeyDown);
            // 
            // CornerTextbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cornerRadiusPanel1);
            this.Name = "CornerTextbox";
            this.Size = new System.Drawing.Size(603, 60);
            this.cornerRadiusPanel1.ResumeLayout(false);
            this.cornerRadiusPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CornerRadiusPanel cornerRadiusPanel1;
        private System.Windows.Forms.TextBox TextBoxForInputBox;
    }
}

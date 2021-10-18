
namespace demoForWinFormFrame.Controls
{
    partial class LabelButton
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
            this.CornerRadiusPanel = new demoForWinFormFrame.Controls.CornerRadiusPanel();
            this.TextBlockForNaviBack = new System.Windows.Forms.Label();
            this.CornerRadiusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CornerRadiusPanel
            // 
            this.CornerRadiusPanel.Controls.Add(this.TextBlockForNaviBack);
            this.CornerRadiusPanel.Location = new System.Drawing.Point(-11, -12);
            this.CornerRadiusPanel.Name = "CornerRadiusPanel";
            this.CornerRadiusPanel.Size = new System.Drawing.Size(85, 105);
            this.CornerRadiusPanel.TabIndex = 1;
            this.CornerRadiusPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CornerRadiusPanel_MouseDown);
            // 
            // TextBlockForNaviBack
            // 
            this.TextBlockForNaviBack.AutoSize = true;
            this.TextBlockForNaviBack.Font = new System.Drawing.Font("宋体", 12F);
            this.TextBlockForNaviBack.Location = new System.Drawing.Point(15, 21);
            this.TextBlockForNaviBack.Name = "TextBlockForNaviBack";
            this.TextBlockForNaviBack.Size = new System.Drawing.Size(31, 16);
            this.TextBlockForNaviBack.TabIndex = 1;
            this.TextBlockForNaviBack.Text = "222";
            this.TextBlockForNaviBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBlockForNaviBack_MouseDown);
            // 
            // LabelButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.CornerRadiusPanel);
            this.Name = "LabelButton";
            this.Size = new System.Drawing.Size(45, 45);
            this.CornerRadiusPanel.ResumeLayout(false);
            this.CornerRadiusPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CornerRadiusPanel CornerRadiusPanel;
        private System.Windows.Forms.Label TextBlockForNaviBack;
    }
}

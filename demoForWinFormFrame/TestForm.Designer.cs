namespace demoForWinFormFrame
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cornerRadiusPanel1 = new demoForWinFormFrame.Controls.CornerRadiusPanel();
            this.cornerTextbox1 = new demoForWinFormFrame.Controls.CornerTextbox();
            this.labelButton1 = new demoForWinFormFrame.Controls.LabelButton();
            this.SuspendLayout();
            // 
            // cornerRadiusPanel1
            // 
            this.cornerRadiusPanel1.Location = new System.Drawing.Point(12, 12);
            this.cornerRadiusPanel1.Name = "cornerRadiusPanel1";
            this.cornerRadiusPanel1.Size = new System.Drawing.Size(296, 144);
            this.cornerRadiusPanel1.TabIndex = 0;
            // 
            // cornerTextbox1
            // 
            this.cornerTextbox1.Location = new System.Drawing.Point(12, 182);
            this.cornerTextbox1.Name = "cornerTextbox1";
            this.cornerTextbox1.Size = new System.Drawing.Size(603, 50);
            this.cornerTextbox1.TabIndex = 1;
            // 
            // labelButton1
            // 
            this.labelButton1.BackColor = System.Drawing.Color.Transparent;
            this.labelButton1.IsEnable = false;
            this.labelButton1.Location = new System.Drawing.Point(12, 251);
            this.labelButton1.Name = "labelButton1";
            this.labelButton1.Size = new System.Drawing.Size(45, 45);
            this.labelButton1.TabIndex = 2;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelButton1);
            this.Controls.Add(this.cornerTextbox1);
            this.Controls.Add(this.cornerRadiusPanel1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CornerRadiusPanel cornerRadiusPanel1;
        private Controls.CornerTextbox cornerTextbox1;
        private Controls.LabelButton labelButton1;
    }
}
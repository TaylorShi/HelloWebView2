﻿
namespace demoForWinFormFrame
{
    partial class CornerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CornerForm));
            this.LabelButtonForNaviTarget = new demoForWinFormFrame.Controls.LabelButton();
            this.LabelButtonForNaviHome = new demoForWinFormFrame.Controls.LabelButton();
            this.LabelButtonForNaviForward = new demoForWinFormFrame.Controls.LabelButton();
            this.LabelButtonForNaviBack = new demoForWinFormFrame.Controls.LabelButton();
            this.WebViewForMain = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.cornerTextbox1 = new demoForWinFormFrame.Controls.CornerTextbox();
            this.LabelButtonForNaviRefresh = new demoForWinFormFrame.Controls.LabelButton();
            this.LabelButtonForNaviStop = new demoForWinFormFrame.Controls.LabelButton();
            ((System.ComponentModel.ISupportInitialize)(this.WebViewForMain)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelButtonForNaviTarget
            // 
            this.LabelButtonForNaviTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelButtonForNaviTarget.BackColor = System.Drawing.Color.Transparent;
            this.LabelButtonForNaviTarget.Location = new System.Drawing.Point(1279, 9);
            this.LabelButtonForNaviTarget.Margin = new System.Windows.Forms.Padding(0);
            this.LabelButtonForNaviTarget.Name = "LabelButtonForNaviTarget";
            this.LabelButtonForNaviTarget.Size = new System.Drawing.Size(60, 60);
            this.LabelButtonForNaviTarget.TabIndex = 2;
            // 
            // LabelButtonForNaviHome
            // 
            this.LabelButtonForNaviHome.BackColor = System.Drawing.Color.Transparent;
            this.LabelButtonForNaviHome.Location = new System.Drawing.Point(224, 7);
            this.LabelButtonForNaviHome.Margin = new System.Windows.Forms.Padding(0);
            this.LabelButtonForNaviHome.Name = "LabelButtonForNaviHome";
            this.LabelButtonForNaviHome.Size = new System.Drawing.Size(60, 60);
            this.LabelButtonForNaviHome.TabIndex = 2;
            // 
            // LabelButtonForNaviForward
            // 
            this.LabelButtonForNaviForward.BackColor = System.Drawing.Color.Transparent;
            this.LabelButtonForNaviForward.Location = new System.Drawing.Point(80, 7);
            this.LabelButtonForNaviForward.Margin = new System.Windows.Forms.Padding(0);
            this.LabelButtonForNaviForward.Name = "LabelButtonForNaviForward";
            this.LabelButtonForNaviForward.Size = new System.Drawing.Size(60, 60);
            this.LabelButtonForNaviForward.TabIndex = 2;
            this.LabelButtonForNaviForward.Tapped += new demoForWinFormFrame.Controls.LabelButton.TappedEventHandler(this.LabelButtonForNaviForward_Tapped);
            // 
            // LabelButtonForNaviBack
            // 
            this.LabelButtonForNaviBack.BackColor = System.Drawing.Color.Transparent;
            this.LabelButtonForNaviBack.Location = new System.Drawing.Point(8, 7);
            this.LabelButtonForNaviBack.Margin = new System.Windows.Forms.Padding(0);
            this.LabelButtonForNaviBack.Name = "LabelButtonForNaviBack";
            this.LabelButtonForNaviBack.Size = new System.Drawing.Size(60, 60);
            this.LabelButtonForNaviBack.TabIndex = 1;
            this.LabelButtonForNaviBack.Tapped += new demoForWinFormFrame.Controls.LabelButton.TappedEventHandler(this.LabelButtonForNaviBack_Tapped);
            // 
            // WebViewForMain
            // 
            this.WebViewForMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebViewForMain.CreationProperties = null;
            this.WebViewForMain.DefaultBackgroundColor = System.Drawing.Color.White;
            this.WebViewForMain.Location = new System.Drawing.Point(-2, 77);
            this.WebViewForMain.Name = "WebViewForMain";
            this.WebViewForMain.Size = new System.Drawing.Size(1354, 684);
            this.WebViewForMain.Source = new System.Uri("https://www.bing.com", System.UriKind.Absolute);
            this.WebViewForMain.TabIndex = 3;
            this.WebViewForMain.ZoomFactor = 1D;
            // 
            // cornerTextbox1
            // 
            this.cornerTextbox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cornerTextbox1.Location = new System.Drawing.Point(294, 7);
            this.cornerTextbox1.Name = "cornerTextbox1";
            this.cornerTextbox1.Size = new System.Drawing.Size(973, 60);
            this.cornerTextbox1.TabIndex = 4;
            // 
            // LabelButtonForNaviRefresh
            // 
            this.LabelButtonForNaviRefresh.BackColor = System.Drawing.Color.Transparent;
            this.LabelButtonForNaviRefresh.Location = new System.Drawing.Point(152, 7);
            this.LabelButtonForNaviRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.LabelButtonForNaviRefresh.Name = "LabelButtonForNaviRefresh";
            this.LabelButtonForNaviRefresh.Size = new System.Drawing.Size(60, 60);
            this.LabelButtonForNaviRefresh.TabIndex = 2;
            this.LabelButtonForNaviRefresh.Tapped += new demoForWinFormFrame.Controls.LabelButton.TappedEventHandler(this.LabelButtonForNaviRefresh_Tapped);
            // 
            // LabelButtonForNaviStop
            // 
            this.LabelButtonForNaviStop.BackColor = System.Drawing.Color.Transparent;
            this.LabelButtonForNaviStop.Location = new System.Drawing.Point(152, 7);
            this.LabelButtonForNaviStop.Margin = new System.Windows.Forms.Padding(0);
            this.LabelButtonForNaviStop.Name = "LabelButtonForNaviStop";
            this.LabelButtonForNaviStop.Size = new System.Drawing.Size(60, 60);
            this.LabelButtonForNaviStop.TabIndex = 2;
            this.LabelButtonForNaviStop.Tapped += new demoForWinFormFrame.Controls.LabelButton.TappedEventHandler(this.LabelButtonForNaviStop_Tapped);
            // 
            // CornerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1351, 761);
            this.Controls.Add(this.cornerTextbox1);
            this.Controls.Add(this.WebViewForMain);
            this.Controls.Add(this.LabelButtonForNaviTarget);
            this.Controls.Add(this.LabelButtonForNaviStop);
            this.Controls.Add(this.LabelButtonForNaviRefresh);
            this.Controls.Add(this.LabelButtonForNaviHome);
            this.Controls.Add(this.LabelButtonForNaviForward);
            this.Controls.Add(this.LabelButtonForNaviBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CornerForm";
            this.Text = "MiniEdge";
            ((System.ComponentModel.ISupportInitialize)(this.WebViewForMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.LabelButton LabelButtonForNaviBack;
        private Controls.LabelButton LabelButtonForNaviForward;
        private Controls.LabelButton LabelButtonForNaviHome;
        private Controls.LabelButton LabelButtonForNaviTarget;
        private Microsoft.Web.WebView2.WinForms.WebView2 WebViewForMain;
        private Controls.CornerTextbox cornerTextbox1;
        private Controls.LabelButton LabelButtonForNaviRefresh;
        private Controls.LabelButton LabelButtonForNaviStop;
    }
}
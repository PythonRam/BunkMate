using System;
using System.Windows.Forms;
using System.IO;

namespace Bunk_Mate
{
    /// <summary>
    /// Summary description for Screentshot
    /// </summary>
    public class Screenshot: System.Windows.Forms.Form
    {
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label label2;
        private ALV.ALVCS03CONTROLS.ALVImageViewer alvImageViewer1;
        private System.Windows.Forms.Label lblPage;
        private System.ComponentModel.Container components = null;

        public Screenshot()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
       
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Screenshot));
            this.alvImageViewer1 = new ALV.ALVCS03CONTROLS.ALVImageViewer();
            this.SuspendLayout();
            // 
            // alvImageViewer1
            // 
            this.alvImageViewer1.AutoFitToHeight = false;
            this.alvImageViewer1.AutoFitToScreen = false;
            this.alvImageViewer1.AutoFitToWidth = true;
            this.alvImageViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.alvImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alvImageViewer1.Location = new System.Drawing.Point(0, 0);
            this.alvImageViewer1.Name = "alvImageViewer1";
            this.alvImageViewer1.Size = new System.Drawing.Size(400, 513);
            this.alvImageViewer1.TabIndex = 11;
            this.alvImageViewer1.ZoomRatio = 1D;
            // 
            // Screenshot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(400, 513);
            this.Controls.Add(this.alvImageViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 513);
            this.Name = "Screenshot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screenshot";
            this.Load += new System.EventHandler(this.Screenshot_Load);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       
        
        private void Screenshot_Load(object sender, System.EventArgs e)
        {
            alvImageViewer1.ImageFromFile(@"websisScreenShot.png");
        }


    }
}


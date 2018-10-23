namespace Drawing_Toolkit {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.CanvasPanel = new System.Windows.Forms.Panel();
            this.Tools = new System.Windows.Forms.ToolStrip();
            this.SelectorButton = new System.Windows.Forms.ToolStripButton();
            this.LineButton = new System.Windows.Forms.ToolStripButton();
            this.EllipseButton = new System.Windows.Forms.ToolStripButton();
            this.Tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // CanvasPanel
            // 
            this.CanvasPanel.BackColor = System.Drawing.SystemColors.Window;
            this.CanvasPanel.Location = new System.Drawing.Point(-1, 28);
            this.CanvasPanel.Name = "CanvasPanel";
            this.CanvasPanel.Size = new System.Drawing.Size(801, 425);
            this.CanvasPanel.TabIndex = 0;
            // 
            // Tools
            // 
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectorButton,
            this.LineButton,
            this.EllipseButton});
            this.Tools.Location = new System.Drawing.Point(0, 0);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(800, 25);
            this.Tools.TabIndex = 1;
            this.Tools.Text = "Shape Tools";
            // 
            // SelectorButton
            // 
            this.SelectorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectorButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectorButton.Image")));
            this.SelectorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectorButton.Name = "SelectorButton";
            this.SelectorButton.Size = new System.Drawing.Size(23, 22);
            this.SelectorButton.Text = "Selector Tool";
            // 
            // LineButton
            // 
            this.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineButton.Image = ((System.Drawing.Image)(resources.GetObject("LineButton.Image")));
            this.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(23, 22);
            this.LineButton.Text = "Line Tool";
            // 
            // EllipseButton
            // 
            this.EllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("EllipseButton.Image")));
            this.EllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(23, 22);
            this.EllipseButton.Text = "Ellipse Tool";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Tools);
            this.Controls.Add(this.CanvasPanel);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CanvasPanel;
        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.ToolStripButton LineButton;
        private System.Windows.Forms.ToolStripButton EllipseButton;
        private System.Windows.Forms.ToolStripButton SelectorButton;
    }
}


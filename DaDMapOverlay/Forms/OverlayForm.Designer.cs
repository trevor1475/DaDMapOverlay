using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DaDMapOverlay.Forms
{
    partial class OverlayForm : Form
    {
        private bool isDragging;
        private Point lastMousePosition;

        private List<Bitmap> _mapsToDisplay = new List<Bitmap>();
        public List<Bitmap> MapsToDisplay {
            get
            {
                return _mapsToDisplay;
            }
            set
            {
                foreach (Bitmap bitmap in value)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = bitmap;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Margin = new Padding(10);
                    ImagePanel.Controls.Add(pictureBox);
                }

                _mapsToDisplay = value;
            }
        }

        public int MapOpacity {
            get
            {
                return (int)this.Opacity;
            }
            set
            {
                this.Opacity = value;
            }
        }

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
            this.ImagePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // ImagePanel
            // 
            this.ImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePanel.Location = new System.Drawing.Point(0, 0);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(282, 253);
            this.ImagePanel.TabIndex = 0;
            // 
            // OverlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.ImagePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OverlayForm";
            this.ShowInTaskbar = false;
            this.Text = "OverlayForm";
            this.TopMost = true;
            this.TransparencyKey = this.BackColor;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Overlay_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Overlay_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Overlay_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ImagePanel;

        public void ResizeOverlay()
        {
             this.Size = this.ImagePanel.Size;
        }

        private void Overlay_MouseDown(object sender, MouseEventArgs e)
        {
            // Start dragging when the left mouse button is pressed
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePosition = new Point(e.X, e.Y);
            }
        }

        private void Overlay_MouseMove(object sender, MouseEventArgs e)
        {
            // Drag the form if the left mouse button is held down
            if (isDragging)
            {
                int deltaX = e.X - lastMousePosition.X;
                int deltaY = e.Y - lastMousePosition.Y;

                this.Location = new Point(Location.X + deltaX, Location.Y + deltaY);

                lastMousePosition = new Point(e.X, e.Y);
            }
        }

        private void Overlay_MouseUp(object sender, MouseEventArgs e)
        {
            // Stop dragging when the left mouse button is released
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}
using System;
using System.Windows.Forms;

namespace DaDMapOverlay
{
    partial class SettingsForm : Form
    {
        private bool _isListeningForKey = false;

        private string _resolution = "2560x1440";
        public string Resolution
        {
            get
            {
                return ResolutionValue.Text;
            }
            set
            {
                foreach (string item in ResolutionValue.Items)
                {
                    if (item.Equals(value))
                    {
                        ResolutionValue.SelectedItem = item;
                        break;
                    }
                }
                _resolution = value;
            }
        }

        private Keys _keybinding = Keys.M;
        public Keys Keybinding
        {
            get
            {
                return _keybinding;
            }
            set
            {
                this.KeybindingValue.Text = value.ToString();
                _keybinding = value;
            }
        }

        private int _volume = 100;
        public int Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                this.VolumeValue.Value = value;
                _volume = value;
            }
        }

        private int _overlayOpacity = 100;
        public int OverlayOpacity
        {
            get
            {
                return _overlayOpacity;
            }
            set
            {
                this.OpacityValue.Value = value;
                _overlayOpacity = value;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.KeybindingLabel = new System.Windows.Forms.Label();
            this.KeybindingValue = new System.Windows.Forms.TextBox();
            this.ResolutionLabel = new System.Windows.Forms.Label();
            this.ResolutionValue = new System.Windows.Forms.ComboBox();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.VolumeValue = new System.Windows.Forms.TrackBar();
            this.OpacityLabel = new System.Windows.Forms.Label();
            this.OpacityValue = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityValue)).BeginInit();
            this.SuspendLayout();
            // 
            // KeybindingLabel
            // 
            this.KeybindingLabel.AutoSize = true;
            this.KeybindingLabel.Location = new System.Drawing.Point(10, 10);
            this.KeybindingLabel.Name = "KeybindingLabel";
            this.KeybindingLabel.Size = new System.Drawing.Size(73, 16);
            this.KeybindingLabel.TabIndex = 3;
            this.KeybindingLabel.Text = "Open Map:";
            // 
            // KeybindingValue
            // 
            this.KeybindingValue.Enabled = false;
            this.KeybindingValue.Location = new System.Drawing.Point(150, 10);
            this.KeybindingValue.Name = "KeybindingValue";
            this.KeybindingValue.Size = new System.Drawing.Size(100, 22);
            this.KeybindingValue.TabIndex = 0;
            this.KeybindingValue.Text = "M";
            // 
            // ResolutionLabel
            // 
            this.ResolutionLabel.AutoSize = true;
            this.ResolutionLabel.Location = new System.Drawing.Point(10, 60);
            this.ResolutionLabel.Name = "ResolutionLabel";
            this.ResolutionLabel.Size = new System.Drawing.Size(120, 16);
            this.ResolutionLabel.TabIndex = 4;
            this.ResolutionLabel.Text = "Screen Resolution:";
            // 
            // ResolutionValue
            // 
            this.ResolutionValue.FormattingEnabled = true;
            this.ResolutionValue.Items.AddRange(new object[] {
            "1920x1080",
            "2560x1440",
            "3840x2160"});
            this.ResolutionValue.Location = new System.Drawing.Point(150, 60);
            this.ResolutionValue.Name = "ResolutionValue";
            this.ResolutionValue.Size = new System.Drawing.Size(100, 24);
            this.ResolutionValue.TabIndex = 1;
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Location = new System.Drawing.Point(10, 110);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(56, 16);
            this.VolumeLabel.TabIndex = 3;
            this.VolumeLabel.Text = "Volume:";
            // 
            // VolumeValue
            // 
            this.VolumeValue.Location = new System.Drawing.Point(110, 110);
            this.VolumeValue.Maximum = 100;
            this.VolumeValue.Name = "VolumeValue";
            this.VolumeValue.Size = new System.Drawing.Size(150, 56);
            this.VolumeValue.TabIndex = 2;
            this.VolumeValue.Value = 100;
            // 
            // OpacityLabel
            // 
            this.OpacityLabel.AutoSize = true;
            this.OpacityLabel.Location = new System.Drawing.Point(10, 160);
            this.OpacityLabel.Name = "OpacityLabel";
            this.OpacityLabel.Size = new System.Drawing.Size(56, 16);
            this.OpacityLabel.TabIndex = 5;
            this.OpacityLabel.Text = "Opacity:";
            // 
            // OpacityValue
            // 
            this.OpacityValue.Location = new System.Drawing.Point(110, 160);
            this.OpacityValue.Maximum = 100;
            this.OpacityValue.Name = "OpacityValue";
            this.OpacityValue.Size = new System.Drawing.Size(150, 56);
            this.OpacityValue.TabIndex = 3;
            this.OpacityValue.Value = 100;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 205);
            this.Controls.Add(this.OpacityValue);
            this.Controls.Add(this.OpacityLabel);
            this.Controls.Add(this.VolumeValue);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.ResolutionValue);
            this.Controls.Add(this.ResolutionLabel);
            this.Controls.Add(this.KeybindingValue);
            this.Controls.Add(this.KeybindingLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.VolumeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void KeybindTextBox_Click(object sender, EventArgs e)
        {
            // Listen for the next key or mouse button pressed
            _isListeningForKey = true;
            this.KeybindingValue.Text = "...";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_isListeningForKey)
            {
                // Ignore Mouse Button 1 (left button) and Mouse Button 2 (right button)
                if (keyData != Keys.LButton && keyData != Keys.RButton)
                {
                    Keybinding = keyData;
                }

                _isListeningForKey = false;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        private Label KeybindingLabel;
        private TextBox KeybindingValue;
        private Label ResolutionLabel;
        private ComboBox ResolutionValue;
        private Label VolumeLabel;
        private TrackBar VolumeValue;
        private Label OpacityLabel;
        private TrackBar OpacityValue;
    }
}


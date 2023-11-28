using DaDMapOverlay.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DaDMapOverlay
{
    internal static class Program
    {
        private static SettingsForm _settingsForm;
        private static OverlayForm _overlayForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _settingsForm = new SettingsForm();
            _overlayForm = new OverlayForm();

            
            var trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Settings", OpenSettings);
            trayMenu.MenuItems.Add("Exit", Exit);

            var trayIcon = new NotifyIcon();
            trayIcon.Text = "Map Overlay Program";
            trayIcon.Icon = new Icon("DadMapIcon.ico");

            // Attach the menu to the tray icon
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            Application.Run();
        }

        private static void ShowMapOverlay()
        {
            if (_overlayForm.Visible)
            {
                //_overlayForm.MapsToDisplay = 
                //_overlayForm.ClearCircles();
                //_overlayForm.AddCircles();
                _overlayForm.ResizeOverlay();
                _overlayForm.Visible = true;
            }
            else
            {
                _overlayForm.Visible = false;
            }
        }

        private static void OpenSettings(object sender, EventArgs e)
        {
            // Show the settings form
            _settingsForm.Show();
        }

        private static void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the settings when the settings form is closed
            //SaveSettings();
        }

        private static void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

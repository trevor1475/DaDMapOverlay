using DaDMapOverlay.Forms;
using DaDMapOverlay.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DaDMapOverlay
{
    internal static class Program
    {
        private static SettingsUtil _settings;
        private static SettingsForm _settingsForm;
        private static OverlayForm _overlayForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _settings = new SettingsUtil();

            _settingsForm = new SettingsForm();
            _settingsForm.OverlayKeybinding = _settings.OverlayKeybinding;
            //bind hotkey
            _settingsForm.OverlayKeybindingChanged += SettingsForm_OverlayKeybindingChanged;
            //cache images
            _settingsForm.GameResolution = _settings.GameResolution;
            _settingsForm.GameResolutionChanged += SettingsForm_GameResolutionChanged;
            //set tts volume
            _settingsForm.Volume = _settings.Volume;
            _settingsForm.VolumeChanged += SettingsForm_VolumeChanged;
            _settingsForm.OverlayOpacity = _settings.OverlayOpacity;
            _settingsForm.OverlayOpacityChanged += SettingsForm_OverlayOpacityChanged;

            _overlayForm = new OverlayForm();

            var lastOverlayPosition = _settings.LastOverlayPosition;
            if (!lastOverlayPosition.HasValue || lastOverlayPosition.Value.Equals(new Point(-1, -1)))
            {
                _overlayForm.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                _overlayForm.StartPosition = FormStartPosition.Manual;
                _overlayForm.Location = lastOverlayPosition.Value;
            }

            _overlayForm.LastMousePositionChanged += OverlayForm_LastMousePositionChanged;
            _overlayForm.Opacity = _settings.OverlayOpacity;

            var trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Settings", OpenSettings);
            trayMenu.MenuItems.Add("Exit", Exit);

            var trayIcon = new NotifyIcon();
            trayIcon.Text = "Map Overlay Program";
            trayIcon.Icon = new Icon("DadMapIcon.ico");
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            Application.Run();
        }

        private static void SettingsForm_OverlayKeybindingChanged(object sender, EventArgs e)
        {
            //rebind hotkey
            _settings.OverlayKeybinding = _settingsForm.OverlayKeybinding;
        }

        private static void SettingsForm_GameResolutionChanged(object sender, EventArgs e)
        {
            //re-cache images
            _settings.GameResolution = _settingsForm.GameResolution;
        }

        private static void SettingsForm_VolumeChanged(object sender, EventArgs e)
        {
            //change tts volume
            _settings.Volume = _settingsForm.Volume;
        }

        private static void SettingsForm_OverlayOpacityChanged(object sender, EventArgs e)
        {
            _overlayForm.Opacity = _settingsForm.OverlayOpacity;
            _settings.OverlayOpacity = _settingsForm.OverlayOpacity;
        }

        private static void OverlayForm_LastMousePositionChanged(object sender, EventArgs e)
        {
            _settings.LastOverlayPosition = _overlayForm.Location;
        }

        private static void ShowMapOverlay()
        {
            if (_overlayForm.Visible)
            {
                //_overlayForm.MapsToDisplay = 
                //_overlayForm.ClearCircles();
                //_overlayForm.AddCircles();
                _overlayForm.ResizeOverlay();
                _overlayForm.Show();
            }
            else
            {
                _overlayForm.Hide();
            }
        }

        private static void OpenSettings(object sender, EventArgs e)
        {
            _settingsForm.Show();
        }

        private static void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

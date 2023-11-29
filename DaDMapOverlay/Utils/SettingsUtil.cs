using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace DaDMapOverlay.Utils
{
    internal class SettingsUtil
    {
        internal Keys OverlayKeybinding
        {
            get
            {
                return Properties.Settings.Default.OverlayKeybinding;
            }
            set
            {
                Properties.Settings.Default.OverlayKeybinding = value;
                Properties.Settings.Default.Save();
            }
        }

        internal string GameResolution
        {
            get
            {
                string res = Properties.Settings.Default.GameResolution;
                if (string.IsNullOrEmpty(res))
                {
                    return $"{Screen.PrimaryScreen.Bounds.Width}x{Screen.PrimaryScreen.Bounds.Height}";
                }

                return res;
            }
            set
            {
                Properties.Settings.Default.GameResolution = value;
                Properties.Settings.Default.Save();
            }
        }

        internal int Volume
        {
            get
            {
                return Properties.Settings.Default.Volume;
            }
            set
            {
                Properties.Settings.Default.Volume = value;
                Properties.Settings.Default.Save();
            }
        }

        internal int OverlayOpacity
        {
            get
            {
                return Properties.Settings.Default.OverlayOpacity;
            }
            set
            {
                Properties.Settings.Default.OverlayOpacity = value;
                Properties.Settings.Default.Save();
            }
        }

        internal Point? LastOverlayPosition
        {
            get
            {
                return Properties.Settings.Default.LastOverlayPosition;
            }
            set
            {
                Properties.Settings.Default.LastOverlayPosition = value ?? new Point(-1, -1);
                Properties.Settings.Default.Save();
            }
        }
    }
}

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DaDMapOverlay.Utils
{
    internal class ActiveApplicationUtils
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private const int MAX_WINDOW_TITLE_LENGTH = 256;

        static string GetActiveApplication()
        {
            IntPtr foregroundWindow = GetForegroundWindow();

            if (foregroundWindow != IntPtr.Zero)
            {
                StringBuilder windowTitle = new StringBuilder(MAX_WINDOW_TITLE_LENGTH);
                GetWindowText(foregroundWindow, windowTitle, MAX_WINDOW_TITLE_LENGTH);
                return windowTitle.ToString();
            }

            return null;
        }
    }
}


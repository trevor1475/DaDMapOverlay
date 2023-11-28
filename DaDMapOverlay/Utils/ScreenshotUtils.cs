using DaDMapOverlay.DTOs;
using System.Drawing;

namespace DaDMapOverlay.Utils
{
    internal static class ScreenshotUtils
    {
        internal static SplitMinimapScreenshot SplitScreenshot(Bitmap screenshot)
        {
            // Split into 9 tiles
            int tileSizeX = screenshot.Width / 3;
            int tileSizeY = screenshot.Height / 3;

            var splitMinimapScreenshot = new SplitMinimapScreenshot();

            // Split the screenshot into individual tiles
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Rectangle tileBounds = new Rectangle(i * tileSizeX, j * tileSizeY, tileSizeX, tileSizeY);

                    // If we are on the middle tile, we ignore it since the cursor will cause the image comparison to fail
                    // But we want to show the middle position of it on the map overlay
                    if (i == 1 && j == 1)
                    {
                        splitMinimapScreenshot.CenterPoint = new Point(tileBounds.Left + (tileBounds.Width / 2), tileBounds.Top + (tileBounds.Height / 2));
                    }
                    else
                    {
                        splitMinimapScreenshot.Tiles.Add(screenshot.Clone(tileBounds, screenshot.PixelFormat));
                    }
                }
            }

            return splitMinimapScreenshot;
        }

        internal static Bitmap TakeMinimapScreenshot(string resolution)
        {
            string[] res = resolution.Split('x');
            int screenW = int.Parse(res[0]);
            int screenH = int.Parse(res[1]);

            int startX = (int)(2230 / 2560 * screenW);
            int startY = (int)(1110 / 1440 * screenH);
            int endX = (int)(2515 / 2560 * screenW);
            int endY = (int)(1385 / 1440 * screenH);

            int width = endX - startX;
            int height = endY - startY;

            Bitmap screenshot = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(screenshot);

            graphics.CopyFromScreen(startX, startY, 0, 0, new Size(width, height));
            graphics.DrawImage(screenshot, 0, 0, width, height);

            return screenshot;
        }
    }
}

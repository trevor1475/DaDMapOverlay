using System.Collections.Generic;
using System.Drawing;

namespace DaDMapOverlay.DTOs
{
    internal class SplitMinimapScreenshot
    {
        public Point CenterPoint { get; set; }
        public List<Bitmap> Tiles { get; set; }
    }
}

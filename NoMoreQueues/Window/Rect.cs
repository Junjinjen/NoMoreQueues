using System.Drawing;
using System.Runtime.InteropServices;

namespace NoMoreQueues.Window
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Rect
    {
        public int Left;

        public int Top;

        public int Right;

        public int Bottom;

        public int Width => Right - Left;

        public int Height => Bottom - Top;

        public Size Size => new(Width, Height);
    }
}

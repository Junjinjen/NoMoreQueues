using NoMoreQueues.ProgramInput.Internal.PInvoke;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace NoMoreQueues.Window
{
    public static class WindowManager
    {
        private static Bitmap _bitmap;

        public static void ActivateWindow(Process process)
        {
            var result = SetForegroundWindow(process.MainWindowHandle);
            if (!result)
            {
                throw new Win32Exception();
            }
        }

        public static Bitmap GetWindowScreenshot(Process process)
        {
            var result = GetWindowRect(process.MainWindowHandle, out var rect);
            if (!result)
            {
                throw new Win32Exception();
            }

            var image = GetBitmap(rect.Width, rect.Height);
            using var graphics = Graphics.FromImage(image);
            graphics.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);

            return image;
        }

        public static Size GetPrimaryDisplaySize()
        {
            return new Size(InputManager.GetSystemMetrics(SystemMetric.PrimaryDisplayWidth), InputManager.GetSystemMetrics(SystemMetric.PrimaryDisplayHeight));
        }

        private static Bitmap GetBitmap(int width, int height)
        {
            if (_bitmap?.Width != width || _bitmap?.Height != height)
            {
                _bitmap?.Dispose();
                _bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            }

            return _bitmap;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);
    }
}

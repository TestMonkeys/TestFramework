using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TestMonkeys.Auditing.Events;

namespace TestMonkeys.Auditing
{
    public class Audit
    {
        public static event EventHandler<MessageLoggedEventArgs> MessageLogged;
        public static event EventHandler<ImageLoggedEventArgs> ImageLogged;

        public static void Log(string message, Level level)
        {
            Log(null, message, level);
        }

        public static void Log(object sender, string message, Level level)
        {
            if (MessageLogged != null)
            {
                MessageLogged(null, new MessageLoggedEventArgs
                    {
                        Sender = sender,
                        Level = level,
                        Message = message
                    });
            }
        }

        public static void LogImage(object sender, Bitmap image, string message, Level level)
        {
            if (ImageLogged != null)
            {
                ImageLogged(null, new ImageLoggedEventArgs
                {
                    Image = image,
                    Level = level,
                    Message = message,
                    Sender = sender
                });
            }
        }

        public static void LogScreenshot(object sender, string message, Level level)
        {
            if (ImageLogged != null)
            {
                Size sz = Screen.PrimaryScreen.Bounds.Size;
                IntPtr hDesk = GetDesktopWindow();
                IntPtr hSrce = GetWindowDC(hDesk);
                IntPtr hDest = CreateCompatibleDC(hSrce);
                IntPtr hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
                IntPtr hOldBmp = SelectObject(hDest, hBmp);
                bool b=BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, 0, 0,
                       CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
                Bitmap bmp = Image.FromHbitmap(hBmp);
                SelectObject(hDest, hOldBmp);
                DeleteObject(hBmp);
                DeleteDC(hDest);
                ReleaseDC(hDesk, hSrce);

                ImageLogged(null, new ImageLoggedEventArgs
                    {
                        Image = bmp,
                        Level = level,
                        Message = message,
                        Sender = sender
                    });
            }
        }

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource,
                                          int xSrc, int ySrc, CopyPixelOperation rop);

        [DllImport("user32.dll")]
        private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr DeleteDC(IntPtr hDc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr DeleteObject(IntPtr hDc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr ptr);
    }
}
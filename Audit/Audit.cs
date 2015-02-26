using System;
using System.Drawing;
using TestMonkeys.Auditing.Events;
using Image = TestMonkeys.Auditing.Items.Image;

namespace TestMonkeys.Auditing
{
    public class Audit
    {
        private static IScreenShotProvider screenShotProvider;

        /// <summary>
        ///     Gets or Sets the ScreenShotProvider
        /// </summary>
        public static IScreenShotProvider ScreenShotProvider
        {
            get { return screenShotProvider ?? (screenShotProvider = new DefaultScreenShotProvider()); }
            set { screenShotProvider = value; }
        }

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

        public static void LogImage(Bitmap bitmap, string message, Level level)
        {
            LogImage(null, bitmap, message, level);
        }

        public static void LogImage(object sender, Bitmap bitmap, string message, Level level)
        {
            if (ImageLogged != null)
            {
                ImageLogged(null, new ImageLoggedEventArgs
                {
                    Image = bitmap,
                    Level = level,
                    Message = message,
                    Sender = sender
                });
            }
        }

        public static void LogImage(Image image, string message, Level level)
        {
            LogImage(null, image, message, level);
        }

        public static void LogImage(object sender, Image image, string message, Level level)
        {
            if (ImageLogged != null)
            {
                ImageLogged(null, new ImageLoggedEventArgs
                {
                    Image = image.Bitmap,
                    Level = level,
                    Message = message,
                    Sender = sender
                });
            }
        }

        public static void LogScreenShot(string message, Level level)
        {
            LogScreenShot(null, message, level);
        }

        public static void LogScreenShot(object sender, string message, Level level)
        {
            if (ImageLogged != null)
            {
                ImageLogged(null, new ImageLoggedEventArgs
                {
                    Image = ScreenShotProvider.GetScreenShot(),
                    Level = level,
                    Message = message,
                    Sender = sender
                });
            }
        }

        public static void LogScreenShot(IScreenShotProvider customScreenShotProvider, string message, Level level)
        {
            LogScreenShot(null, customScreenShotProvider, message, level);
        }

        public static void LogScreenShot(object sender, IScreenShotProvider customScreenShotProvider, string message,
            Level level)
        {
            if (ImageLogged != null)
            {
                ImageLogged(null, new ImageLoggedEventArgs
                {
                    Image = customScreenShotProvider.GetScreenShot(),
                    Level = level,
                    Message = message,
                    Sender = sender
                });
            }
        }
    }
}
using System.Drawing;
using OpenQA.Selenium;

namespace TestMonkeys.CoreUI.Management
{
    public class Window
    {
        private readonly IWindow window;

        internal Window(IWindow window)
        {
            this.window = window;
        }

        public Point Position
        {
            get { return window.Position; }
            set { window.Position = value; }
        }

        public Size Size
        {
            get { return window.Size; }
            set { window.Size = value; }
        }

        public void Maximize()
        {
            window.Maximize();
        }
    }
}
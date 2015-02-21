using OpenQA.Selenium;

namespace TestMonkeys.CoreUI.Management
{
    public class Options
    {
        private readonly IOptions options;

        internal Options(IOptions options)
        {
            this.options = options;
        }

        public CookieJar Cookies
        {
            get { return new CookieJar(options.Cookies); }
        }

        public Window Window
        {
            get { return new Window(options.Window); }
        }

        public Timeouts Timeouts()
        {
            return new Timeouts(options.Timeouts());
        }
    }
}
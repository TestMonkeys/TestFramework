using TestMonkeys.CoreUI.Html;

namespace TestMonkeys.CoreUI
{
    public class TargetLocator
    {
        private readonly Browser browser;

        internal TargetLocator(Browser browser)
        {
            this.browser = browser;
        }

        public void Frame(int frameIndex)
        {
            browser.Driver.SwitchTo().Frame(frameIndex);
        }

        public void Frame(string frameName)
        {
            browser.Driver.SwitchTo().Frame(frameName);
        }

        public void Frame(HtmlControl frameElement)
        {
            browser.Driver.SwitchTo().Frame(frameElement.WebElement);
        }

        public void Window(string windowName)
        {
            browser.Driver.SwitchTo().Window(windowName);
        }

        public void DefaultContent()
        {
            browser.Driver.SwitchTo().DefaultContent();
        }

        public void ActiveElement()
        {
            browser.Driver.SwitchTo().ActiveElement();
        }

        public Alert Alert()
        {
            return new Alert(browser.Driver.SwitchTo().Alert());
        }
    }
}
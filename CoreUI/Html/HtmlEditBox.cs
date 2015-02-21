using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestMonkeys.CoreUI.Html
{
    public class HtmlEditBox : HtmlControl
    {
        public new string Text
        {
            get { return webElement.GetAttribute("value"); }
            set
            {
                ((IJavaScriptExecutor) ((RemoteWebElement) webElement).WrappedDriver).ExecuteScript(
                    "arguments[0].setAttribute('value', '" + value + "')",
                    webElement);
            }
        }

        public new void SendKeys(string keys)
        {
            base.SendKeys(Keys.Control + "a");
            base.SendKeys(keys);
        }
    }
}
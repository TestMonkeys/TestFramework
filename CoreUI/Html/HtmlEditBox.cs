using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TestMonkeys.CoreUI.Html
{
    public class HtmlEditBox : HtmlControl
    {
        public new string Text
        {
            get { return WebElement.GetAttribute("value"); }
            set
            {
                ((IJavaScriptExecutor) ((RemoteWebElement) WebElement).WrappedDriver).ExecuteScript(
                    "arguments[0].setAttribute('value', '" + value + "')",
                    WebElement);
            }
        }

        public new void SendKeys(string keys)
        {
            base.SendKeys(Keys.Control + "a");
            base.SendKeys(keys);
        }
    }
}
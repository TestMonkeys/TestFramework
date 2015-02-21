using OpenQA.Selenium;

namespace TestMonkeys.CoreUI.Html
{
    public class HtmlLink : HtmlControl
    {
        //internal HtmlLink(IWebElement webElement) : base(webElement)
        //{
        //}

        public string Href
        {
            get { return GetAttribute("href"); }
        }

        public void Go()
        {
            SendKeys(Keys.Enter);
        }
    }
}
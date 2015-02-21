using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using TestMonkeys.CoreUI.Capabilities;
using By = TestMonkeys.CoreUI.Search.By;

namespace TestMonkeys.CoreUI.Html
{
    public class HtmlControl : ICanFindElements
    {
        protected IWebElement webElement;

        internal IWebElement WebElement
        {
            get { return webElement; }
            set { webElement = value; }
        }

        public string TagName
        {
            get { return webElement.TagName; }
        }

        public string Text
        {
            get { return webElement.Text; }
        }

        public bool Enabled
        {
            get { return webElement.Enabled; }
        }

        protected bool IsSelected
        {
            get { return webElement.Selected; }
        }

        public Point Location
        {
            get { return webElement.Location; }
        }

        public Size Size
        {
            get { return webElement.Size; }
        }

        public bool Displayed
        {
            get { return webElement.Displayed; }
        }

        public HtmlControl FindElementByXpath(string xpath)
        {
            return new HtmlControl {webElement = webElement.FindElement(OpenQA.Selenium.By.XPath(xpath))};
        }

        public T FindElementByXpath<T>(string xpath) where T : HtmlControl, new()
        {
            var component = new T {WebElement = webElement.FindElement(OpenQA.Selenium.By.XPath(xpath))};
            return component;
        }

        public List<HtmlControl> FindElementsByXpath(string xpath)
        {
            return
                webElement.FindElements(OpenQA.Selenium.By.XPath(xpath))
                          .Select(x => new HtmlControl {webElement = x})
                          .ToList();
        }

        public List<T> FindElementsByXpath<T>(string xpath) where T : HtmlControl, new()
        {
            return webElement.FindElements(OpenQA.Selenium.By.XPath(xpath)).Select(x => new T {WebElement = x}).ToList();
        }

        public T FindElement<T>(By by) where T : HtmlControl, new()
        {
            return new T {WebElement = webElement.FindElement(by.SeleniumBy())};
        }

        public List<T> FindElements<T>(By by) where T : HtmlControl, new()
        {
            return webElement.FindElements(by.SeleniumBy()).Select(x => new T {WebElement = x}).ToList();
        }

        public void Clear()
        {
            webElement.Clear();
        }

        public void SendKeys(string text)
        {
            webElement.SendKeys(text);
        }

        public void Submit()
        {
            webElement.Submit();
        }

        public void Click()
        {
            webElement.Click();
        }

        public string GetAttribute(string attributeName)
        {
            return webElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return webElement.GetCssValue(propertyName);
        }
    }
}
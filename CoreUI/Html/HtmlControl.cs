using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using TestMonkeys.CoreUI.Capabilities;
using By = TestMonkeys.CoreUI.Search.By;

namespace TestMonkeys.CoreUI.Html
{
    public class HtmlControl :NativeSearchCapable, ICanFindElements, ICanFindElementsByXpath,Compatibility.IWebElement
    {
        protected NativeSearchCapable parent;
        protected By selector;
        private IWebElement webElement;

        internal HtmlControl() { }

        public HtmlControl(NativeSearchCapable parent, By selector)
        {
            this.parent = parent;
            this.selector = selector;
        }

        public NativeSearchCapable Parent
        {
            get { return parent; }
            internal set { parent = value; }
        }

        public By Selector
        {
            get { return selector;}
            internal set { selector = value; }
        }

        internal IWebElement WebElement
        {
            get { return webElement??parent.NativeFindBy(selector.SeleniumBy()); }
            set { webElement = value; }
        }

        public bool Exists
        {
            get
            {
                try
                {
                    return WebElement != null;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public string TagName
        {
            get { return WebElement.TagName; }
        }

        public string Text
        {
            get { return WebElement.Text; }
        }

        public bool Enabled
        {
            get { return WebElement.Enabled; }
        }

        protected bool IsSelected
        {
            get { return WebElement.Selected; }
        }

        [Obsolete("You should use HtmlCheckBox class instead of calling Selected on HtmlControl")]
        public bool Selected
        {
            get { return IsSelected;}
        }

        public Point Location
        {
            get { return WebElement.Location; }
        }

        public Size Size
        {
            get { return WebElement.Size; }
        }

        public bool Displayed
        {
            get { return WebElement.Displayed; }
        }

        public HtmlControl FindElementByXpath(string xpath)
        {
            return new HtmlControl(this,By.XPath(xpath));
        }

        public T FindElementByXpath<T>(string xpath) where T : HtmlControl, new()
        {
            return new T {Parent=this, Selector =By.XPath(xpath)};
        }

        public List<HtmlControl> FindElementsByXpath(string xpath)
        {
            return
                WebElement.FindElements(OpenQA.Selenium.By.XPath(xpath))
                          .Select(x => new HtmlControl { WebElement = x})
                          .ToList();
        }

        public List<T> FindElementsByXpath<T>(string xpath) where T : HtmlControl, new()
        {
            return WebElement.FindElements(OpenQA.Selenium.By.XPath(xpath)).Select(x => new T {WebElement = x}).ToList();
        }

        public HtmlControl FindElement(By by)
        {
            return new HtmlControl {Parent = this,Selector = by};
        }

        public T FindElement<T>(By by) where T : HtmlControl, new()
        {
            return new T {Parent = this, Selector = by};
        }

        public List<HtmlControl> FindElements(By by)
        {
            return webElement.FindElements(by.SeleniumBy()).Select(x => new HtmlControl { WebElement = x }).ToList();
        }

        public List<T> FindElements<T>(By by) where T : HtmlControl, new()
        {
            return WebElement.FindElements(by.SeleniumBy()).Select(x => new T {WebElement = x}).ToList();
        }

        public void Clear()
        {
            WebElement.Clear();
        }

        public void SendKeys(string text)
        {
            WebElement.SendKeys(text);
        }

        public void Submit()
        {
            WebElement.Submit();
        }

        public void Click()
        {
            WebElement.Click();
        }

        public string GetAttribute(string attributeName)
        {
            return WebElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return WebElement.GetCssValue(propertyName);
        }

        internal override IWebElement NativeFindBy(OpenQA.Selenium.By @by)
        {
            return WebElement.FindElement(by);
        }

        Compatibility.IWebElement Compatibility.IWebElement.FindElement(By by)
        {
            return FindElement(by);
        }

        List<Compatibility.IWebElement> Compatibility.IWebElement.FindElements(By by)
        {
            return FindElements(by).Select(x => x as Compatibility.IWebElement).ToList();
        }
    }
}
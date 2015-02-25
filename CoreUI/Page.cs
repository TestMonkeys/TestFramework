using System;
using System.Collections.Generic;
using TestMonkeys.Auditing;
using TestMonkeys.CoreUI.Capabilities;
using TestMonkeys.CoreUI.Html;
using TestMonkeys.CoreUI.Search;
using TestMonkeys.CoreUI.Util;

namespace TestMonkeys.CoreUI
{
    public abstract class Page : ICanFindElements, ICanFindElementsByXpath
    {
        protected Page(Browser browser)
        {
            Browser = browser;
        }

        protected Browser Browser { get; private set; }

        public bool IsCurrentPage
        {
            get { return Browser.Url.Contains(LaunchUrl()); }
        }

        public HtmlControl FindElementByXpath(string xpath)
        {
            WaitUntilPageLoaded();
            return Browser.FindElementByXpath(xpath);
        }

        public T FindElementByXpath<T>(string xpath) where T : HtmlControl, new()
        {
            WaitUntilPageLoaded();
            return Browser.FindElementByXpath<T>(xpath);
        }

        public List<HtmlControl> FindElementsByXpath(string xpath)
        {
            WaitUntilPageLoaded();
            return Browser.FindElementsByXpath(xpath);
        }

        public List<T> FindElementsByXpath<T>(string xpath) where T : HtmlControl, new()
        {
            WaitUntilPageLoaded();
            return Browser.FindElementsByXpath<T>(xpath);
        }

        public HtmlControl FindElement(By by)
        {
            WaitUntilPageLoaded();
            return Browser.FindElement(by);
        }

        public T FindElement<T>(By by) where T : HtmlControl, new()
        {
            WaitUntilPageLoaded();
            return Browser.FindElement<T>(by);
        }

        public List<HtmlControl> FindElements(By by) 
        {
            WaitUntilPageLoaded();
            return Browser.FindElements(by);
        }

        public List<T> FindElements<T>(By by) where T : HtmlControl, new()
        {
            WaitUntilPageLoaded();
            return Browser.FindElements<T>(by);
        }

        public void Launch()
        {
            var currentUri = new Uri(Browser.Url);
            Browser.Navigate().GoToUrl(currentUri.Scheme + "://" + currentUri.DnsSafeHost + LaunchUrl());
        }

        protected abstract string LaunchUrl();


        /// <summary>
        ///     This method should be overriden in case the page has loading splash-screen,
        ///     it should return true if the splash-screen is not displayed
        /// </summary>
        /// <returns></returns>
        protected virtual bool PageLoaded()
        {
            return true;
        }

        private void WaitUntilPageLoaded()
        {
            try
            {
                Wait.UntilTrue(PageLoaded, TimeSpan.FromMinutes(1));
            }
            catch
            {
                Audit.Log(this, "Page didn't load", Level.Error);
            }
        }
    }
}
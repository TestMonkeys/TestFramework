using System;
using OpenQA.Selenium;

namespace TestMonkeys.CoreUI
{
    public class Navigation
    {
        private readonly IWebDriver driver;

        internal Navigation(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Back()
        {
            driver.Navigate().Back();
        }

        public void Forward()
        {
            driver.Navigate().Forward();
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void GoToUrl(Uri url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Refresh()
        {
            driver.Navigate().Refresh();
        }
    }
}
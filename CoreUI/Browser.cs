using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TestMonkeys.CoreUI.Capabilities;
using TestMonkeys.CoreUI.Html;
using TestMonkeys.CoreUI.Management;
using By = TestMonkeys.CoreUI.Search.By;

namespace TestMonkeys.CoreUI
{
    public class Browser : NativeSearchCapable, ICanFindElements, ICanFindElementsByXpath
    {
        private readonly RemoteWebDriver driver;

        internal Browser(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        internal RemoteWebDriver Driver
        {
            get { return driver; }
        }

        public string Url
        {
            get { return driver.Url; }
            set { driver.Url = value; }
        }

        public string Title
        {
            get { return driver.Title; }
        }

        public string PageSource
        {
            get { return driver.PageSource; }
        }

        public string CurrentWindowHandle
        {
            get { return driver.CurrentWindowHandle; }
        }

        public ReadOnlyCollection<string> WindowHandles
        {
            get { return driver.WindowHandles; }
        }

        internal IWebDriver WebDriver
        {
            get { return driver; }
        }

        public HtmlControl FindElementByXpath(string xpath)
        {
            return new HtmlControl {Parent = this, Selector = By.XPath(xpath)};
        }

        public T FindElementByXpath<T>(string xpath) where T : HtmlControl, new()
        {
            return new T {Parent = this,Selector = By.XPath(xpath)};
        }

        public List<HtmlControl> FindElementsByXpath(string xpath)
        {
            return driver.FindElementsByXPath(xpath).Select(x => new HtmlControl {WebElement = x}).ToList();
        }

        public List<T> FindElementsByXpath<T>(string xpath) where T : HtmlControl, new()
        {
            return driver.FindElementsByXPath(xpath).Select(x => new T {WebElement = x}).ToList();
        }

        public HtmlControl FindElement(By by)
        {
            return new HtmlControl { Parent = this, Selector = by};
        }

        public T FindElement<T>(By by) where T : HtmlControl, new()
        {
            return new T { Parent = this, Selector = by };
        }

        public List<HtmlControl> FindElements(By by)
        {
            return driver.FindElements(by.SeleniumBy()).Select(x => new HtmlControl { WebElement = x }).ToList();
        }

        public List<T> FindElements<T>(By by) where T : HtmlControl, new()
        {
            return driver.FindElements(by.SeleniumBy()).Select(x => new T {WebElement = x}).ToList();
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        public void Close()
        {
            driver.Close();
        }

        public void Quit()
        {
            driver.Quit();
        }

        public Bitmap Screenshot()
        {
            var screenshot = driver.GetScreenshot();
            var bitmap = new Bitmap(new MemoryStream(screenshot.AsByteArray));
            return bitmap;
        }

        public Options Manage()
        {
            return new Options(driver.Manage());
        }

        public Navigation Navigate()
        {
            return new Navigation(driver);
        }

        public TargetLocator SwitchTo()
        {
            return new TargetLocator(this);
        }

        internal override IWebElement NativeFindBy(OpenQA.Selenium.By by)
        {
            return driver.FindElement(by);
        }
    }
}
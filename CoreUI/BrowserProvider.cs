using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestMonkeys.CoreUI
{
    public class BrowserProvider
    {
        public static Browser GetBrowserFor(BrowserType browserType, string url)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions {LeaveBrowserRunning = true};
                    //chromeOptions.AddArgument("--incognito");

                    var browser = new Browser(new ChromeDriver(chromeOptions));
                    browser.Navigate().GoToUrl(url);
                    return browser;


                default:
                    throw new NotFoundException("Could not create browser of such type");
            }
        }
    }
}
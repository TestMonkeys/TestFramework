using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMonkeys.ContextManager;
using TestMonkeys.Auditing;
using TestMonkeys.CoreUI;
using TestMonkeys.CoreUI.Html;
using TestMonkeys.CoreUI.Util;

namespace TestMonkeys.Core.test
{
    [TestClass]
    public class SampleUiTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Google_SetText_InSearch()
        {
            LogWatcher.SetContext(TestContext);
            Browser browser = BrowserProvider.GetBrowserFor(BrowserType.Chrome, "http://www.google.com");

            //browser.Navigate().GoToUrl(new Uri("http://www.google.com"));
            //var input = Wait.Until(()=>browser.FindElementByXpath<HtmlEditBox>("//input[@type='text']"),TimeSpan.FromSeconds(30));
           //// Audit.LogImage(this,browser.Screenshot(),"Page",Level.Info);
           // input.Text = "It Works";
           // input.Text = "secondtry";
            Audit.LogImage(this, browser.Screenshot(), "Page", Level.Info);
        }

        [TestMethod]
        public void Audit_ScreenshotTest()
        {
            LogWatcher.SetContext(TestContext);
            Audit.LogScreenshot(this,"TestName",Level.Error);
        }
    }
}
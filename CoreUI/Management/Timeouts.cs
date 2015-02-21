using System;
using OpenQA.Selenium;

namespace TestMonkeys.CoreUI.Management
{
    public class Timeouts
    {
        private readonly ITimeouts timeouts;

        internal Timeouts(ITimeouts timeouts)
        {
            this.timeouts = timeouts;
        }

        public void ImplicitlyWait(TimeSpan timeToWait)
        {
            timeouts.ImplicitlyWait(timeToWait);
        }

        public void SetScriptTimeout(TimeSpan timeToWait)
        {
            timeouts.SetScriptTimeout(timeToWait);
        }

        public void SetPageLoadTimeout(TimeSpan timeToWait)
        {
            timeouts.SetPageLoadTimeout(timeToWait);
        }
    }
}
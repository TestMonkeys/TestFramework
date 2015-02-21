using OpenQA.Selenium;

namespace TestMonkeys.CoreUI
{
    public class Alert
    {
        private readonly IAlert alert;

        internal Alert(IAlert alert)
        {
            this.alert = alert;
        }

        public string Text
        {
            get { return alert.Text; }
        }

        public void Dismiss()
        {
            alert.Dismiss();
        }

        public void Accept()
        {
            alert.Accept();
        }

        public void SendKeys(string keysToSend)
        {
            alert.SendKeys(keysToSend);
        }
    }
}
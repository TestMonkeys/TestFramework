using System;
using System.Collections.Generic;

namespace TestMonkeys.CoreUI.Compatibility
{
    public class Proxy
    {
        public Proxy(Dictionary<string, object> settings)
        {
            SeleniumProxy = new OpenQA.Selenium.Proxy(settings);
        }

        public Proxy()
        {
            SeleniumProxy = new OpenQA.Selenium.Proxy();
        }

        internal Proxy(OpenQA.Selenium.Proxy proxy)
        {
            SeleniumProxy = proxy;
        }

        internal OpenQA.Selenium.Proxy SeleniumProxy { get; private set; }

        public string FtpProxy
        {
            get { return SeleniumProxy.FtpProxy; }
            set { SeleniumProxy.FtpProxy = value; }
        }

        public string HttpProxy
        {
            get { return SeleniumProxy.HttpProxy; }
            set { SeleniumProxy.HttpProxy = value; }
        }

        public bool IsAutoDetect
        {
            get { return SeleniumProxy.IsAutoDetect; }
            set { SeleniumProxy.IsAutoDetect = value; }
        }

        public ProxyKind Kind
        {
            get
            {
                switch (SeleniumProxy.Kind)
                {
                    case OpenQA.Selenium.ProxyKind.AutoDetect:
                        return ProxyKind.AutoDetect;
                    case OpenQA.Selenium.ProxyKind.Direct:
                        return ProxyKind.Direct;
                    case OpenQA.Selenium.ProxyKind.Manual:
                        return ProxyKind.Manual;
                    case OpenQA.Selenium.ProxyKind.ProxyAutoConfigure:
                        return ProxyKind.ProxyAutoConfigure;
                    case OpenQA.Selenium.ProxyKind.System:
                        return ProxyKind.System;
                    case OpenQA.Selenium.ProxyKind.Unspecified:
                        return ProxyKind.Unspecified;
                    default:
                        throw new NotImplementedException("No implementation for converting ProxyKind value");
                }
            }
            set
            {
                switch (value)
                {
                    case ProxyKind.AutoDetect:
                        SeleniumProxy.Kind = OpenQA.Selenium.ProxyKind.AutoDetect;
                        break;
                    case ProxyKind.Direct:
                        SeleniumProxy.Kind = OpenQA.Selenium.ProxyKind.Direct;
                        break;
                    case ProxyKind.Manual:
                        SeleniumProxy.Kind = OpenQA.Selenium.ProxyKind.Manual;
                        break;
                    case ProxyKind.ProxyAutoConfigure:
                        SeleniumProxy.Kind = OpenQA.Selenium.ProxyKind.ProxyAutoConfigure;
                        break;
                    case ProxyKind.System:
                        SeleniumProxy.Kind = OpenQA.Selenium.ProxyKind.System;
                        break;
                    case ProxyKind.Unspecified:
                        SeleniumProxy.Kind = OpenQA.Selenium.ProxyKind.Unspecified;
                        break;
                    default:
                        throw new NotImplementedException("No implementation for converting ProxyKind value");
                }
            } 
        
    }

        public string NoProxy
        {
            get { return SeleniumProxy.NoProxy; }
            set { SeleniumProxy.NoProxy = value; }
        }

        public string ProxyAutoConfigUrl
        {
            get { return SeleniumProxy.ProxyAutoConfigUrl; }
            set { SeleniumProxy.ProxyAutoConfigUrl = value; }
        }

        public string SerializableProxyKind
        {
            get { return SeleniumProxy.SerializableProxyKind; }
        }

        public string SocksPassword
        {
            get { return SeleniumProxy.SocksPassword; }
            set { SeleniumProxy.SocksPassword = value; }
        }

        public string SocksUserName
        {
            get { return SeleniumProxy.SocksUserName; }
            set { SeleniumProxy.SocksUserName = value; }
        }

        public string SslProxy
        {
            get { return SeleniumProxy.SslProxy; }
            set { SeleniumProxy.SslProxy = value; }
        }
    }
}
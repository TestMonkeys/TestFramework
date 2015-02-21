using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Cookie = System.Net.Cookie;

namespace TestMonkeys.CoreUI.Management
{
    public class CookieJar
    {
        private readonly ICookieJar cookieJar;

        internal CookieJar(ICookieJar cookieJar)
        {
            this.cookieJar = cookieJar;
        }

        public List<Cookie> AllCookies
        {
            get { return cookieJar.AllCookies.Select(ToNetCookie).ToList(); }
        }

        public void AddCookie(Cookie cookie)
        {
            cookieJar.AddCookie(ToSeleniumCookie(cookie));
        }

        public Cookie GetCookieNamed(string name)
        {
            return ToNetCookie(cookieJar.GetCookieNamed(name));
        }

        public void DeleteCookie(Cookie cookie)
        {
            cookieJar.DeleteCookie(ToSeleniumCookie(cookie));
        }

        public void DeleteCookieNamed(string name)
        {
            cookieJar.DeleteCookieNamed(name);
        }

        public void DeleteAllCookies()
        {
            cookieJar.DeleteAllCookies();
        }

        private Cookie ToNetCookie(OpenQA.Selenium.Cookie seleniumCookie)
        {
            var cookie = new Cookie(seleniumCookie.Name, seleniumCookie.Value, seleniumCookie.Path,
                                    seleniumCookie.Domain);
            if (seleniumCookie.Expiry.HasValue)
                cookie.Expires = seleniumCookie.Expiry.Value;
            return cookie;
        }

        private OpenQA.Selenium.Cookie ToSeleniumCookie(Cookie netCookie)
        {
            return new OpenQA.Selenium.Cookie(netCookie.Name, netCookie.Value, netCookie.Domain, netCookie.Path,
                                              netCookie.Expires);
        }
    }
}
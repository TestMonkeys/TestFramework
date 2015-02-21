using System;
using System.Collections.Generic;
using TestMonkeys.CoreUI.Capabilities;
using TestMonkeys.CoreUI.Html;

namespace TestMonkeys.CoreUI.Search
{
    public class By
    {
        private readonly SearchMethod searchMethod;
        private readonly string searchValue;

        private By(string searchValue, SearchMethod searchMethod)
        {
            this.searchValue = searchValue;
            this.searchMethod = searchMethod;
        }

        public static By XPath(string value)
        {
            return new By(value, SearchMethod.XPath);
        }

        public static By ClassName(string value)
        {
            return new By(value, SearchMethod.ClassName);
        }

        public static By CssSelector(string value)
        {
            return new By(value, SearchMethod.CssSelector);
        }

        public static By Id(string value)
        {
            return new By(value, SearchMethod.Id);
        }

        public static By LinkText(string value)
        {
            return new By(value, SearchMethod.LinkText);
        }

        public static By Name(string value)
        {
            return new By(value, SearchMethod.Name);
        }

        public static By PartialLinkName(string value)
        {
            return new By(value, SearchMethod.PartialLinkText);
        }

        public static By TagName(string value)
        {
            return new By(value, SearchMethod.TagName);
        }

        public T FindElement<T>(ICanFindElements parent) where T : HtmlControl, new()
        {
            return parent.FindElement<T>(this);
        }

        public List<T> FindElements<T>(ICanFindElements parent) where T : HtmlControl, new()
        {
            return parent.FindElements<T>(this);
        }

        internal OpenQA.Selenium.By SeleniumBy()
        {
            switch (searchMethod)
            {
                case SearchMethod.ClassName:
                    return OpenQA.Selenium.By.ClassName(searchValue);
                case SearchMethod.CssSelector:
                    return OpenQA.Selenium.By.CssSelector(searchValue);
                case SearchMethod.Id:
                    return OpenQA.Selenium.By.Id(searchValue);
                case SearchMethod.LinkText:
                    return OpenQA.Selenium.By.Id(searchValue);
                case SearchMethod.Name:
                    return OpenQA.Selenium.By.Name(searchValue);
                case SearchMethod.PartialLinkText:
                    return OpenQA.Selenium.By.PartialLinkText(searchValue);
                case SearchMethod.TagName:
                    return OpenQA.Selenium.By.TagName(searchValue);
                case SearchMethod.XPath:
                    return OpenQA.Selenium.By.XPath(searchValue);

                default:
                    throw new Exception("Search method <" + searchMethod + "> not implemented");
            }
        }
    }
}
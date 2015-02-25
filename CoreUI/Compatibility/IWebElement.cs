using System.Collections.Generic;
using System.Drawing;
using TestMonkeys.CoreUI.Search;

namespace TestMonkeys.CoreUI.Compatibility
{
    public interface IWebElement
    {
        string TagName { get; }
        string Text { get; }
        bool Enabled { get; }
        bool Selected { get; }
        Point Location { get; }
        Size Size { get; }
        bool Displayed { get; }
        IWebElement FindElement(By @by);
        List<IWebElement> FindElements(By @by);
        void Clear();
        void SendKeys(string text);
        void Submit();
        void Click();
        string GetAttribute(string attributeName);
        string GetCssValue(string propertyName);
    }
}